using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
   // public string currentTextColour, currentTextSize, currentButtonColour;
    public Dropdown textColourDropDown, textSizeDropDown, buttonColourDropDown;
    public int textColour, textSize, buttonColour;
  //  public Text textColourLabel, textSizeLabel, buttonColourLabel;

    private void Update()
    {
      //  textColourLabel.text = currentTextColour;
       // textSizeLabel.text = currentTextSize;
       // buttonColourLabel.text = currentButtonColour;
    }
    public void SetTextColour(int value)
    {
        textColour = value;
    }
    public void SetTextSize(int value)
    {
        textSize = value;
    }
    public void SetButtonColour(int value)
    {
        buttonColour = value;
    }

    public void GetTextColour(int value)
    {
        textColour = value;
    }
    public void GetTextSize(int value)
    {
        textSize = value;
    }
    public void GetButtonColour(int value)
    {
        buttonColour = value;
    }
}
