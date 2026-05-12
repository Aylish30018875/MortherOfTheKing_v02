using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllText : MonoBehaviour
{
    //information about the text components stored in lists to be used by the text manager to apply the font info to them
    //collected text components holds all the text componenents in the scene
    public List<Text> collectedTextComponents = new List<Text>();
    //ignored tag names holds the names of the tags that should be ignored when collecting text components
    public List<string> ignoredTagNames = new List<string>();
    //all text base holds the base font size of all the text components in the scene, so that we can apply the scale to them
    public List<int> allTextBase = new List<int>();
    public FontInfo fontInfo;

    // combines both functions that need to be called into one :)
    void UpdateAllText()
    {
        RefreshCollectedTextComponents();
        UpdateFont();
    }

    private void Awake()
    {
        //update all that stuff at start 
        UpdateAllText();
    }

    public void RefreshCollectedTextComponents()
    {
        //clear the list of collected text components to avoid duplicates
        collectedTextComponents.Clear();

        //scene finds out current scene
        Scene currentScene = gameObject.scene;
        //root game objects finds all the root game objects in the scene, so that we can search through them for text components
        GameObject[] rootGameOobjects = currentScene.GetRootGameObjects();

        //loop through all the root game objects in the scene
        foreach (GameObject rootGameObject in rootGameOobjects)
        {
            //text components in children finds all the text components in the children of the root game object, so that we can add them to the list of collected text components
            Text[] textComponenetsInChildren = rootGameObject.GetComponentsInChildren<Text>(true);

            //loop through all the text components in the children of the root game object
            foreach (Text textComponent in textComponenetsInChildren)
            {
                //if the text component is not tagged with any of the ignored tag names, then we add it to the list of collected text components
                if (ShouldIgnoreGameObject(textComponent.gameObject) == false)
                {
                    //add the text component to the list of collected text components and add its base font size to the list of all text base
                    collectedTextComponents.Add(textComponent);
                    allTextBase.Add(textComponent.fontSize);
                }
            }
        }
    }

    public void ResetTextSize()
    {
        //loop through all the collected text components and reset their font size to their base font size
        for (int i = 0; i < collectedTextComponents.Count; i++)
        {
            //reset the font size of the text component to its base font size
            collectedTextComponents[i].fontSize = allTextBase[i];
        }
    }
    private bool ShouldIgnoreGameObject(GameObject gameObjectToCheck)
    {
        string gameObjectTagName = gameObjectToCheck.tag;

        foreach (string ignoredTagName in ignoredTagNames)
        {
            //if the ignored tag name is null or empty, we skip it to avoid errors
            if (string.IsNullOrEmpty(ignoredTagName) == true)
            {
                continue;
            }
            //if the game object tag name is the same as the ignored tag name, we return true to indicate that we should ignore this game object
            if (gameObjectTagName == ignoredTagName)
            {
                return true;
            }
        }
        //if not, then we return false to not ignore this one
        return false;
    }

    public void UpdateFont()
    {
        //get the font info from the load from save class, so that we can apply the color and scale to the text components
        fontInfo = LoadFromSave.GetDataToSaveFont();

        //reset the font size of all the text components to their base font size before applying the new scale, so that we don't end up with exponentially increasing font sizes when we change the scale multiple times D:
        ResetTextSize();

        //loop through all the collected text components and update their color and font size based on the font info
        foreach (Text textComponent in collectedTextComponents)
        {
            //update the color of the text component to the color specified in the font info
            textComponent.color = fontInfo.color;
            //update the font size of the text component by multiplying it with the scale specified in the font info
            textComponent.fontSize = (int)(textComponent.fontSize * fontInfo.scale);
        }
    }
}
[Serializable]
public class FontInfo
{
    //the color and scale of the text so we can change them :)
    public Color color = Color.white;
    public float scale;
}
