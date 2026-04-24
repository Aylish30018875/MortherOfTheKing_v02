using UnityEngine;
using System;
using UnityEngine.UI;

public class Keybind : MonoBehaviour
{
    [SerializeField] private Text buttonLabel;

    private void Start()
    {
        buttonLabel.text = PlayerPrefs.GetString("CustomKey");
    }

    private void Update()
    {
        if (buttonLabel.text == "Press a key...")
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    buttonLabel.text = key.ToString();
                    
                    PlayerPrefs.SetString("CustomKey", key.ToString());
                    PlayerPrefs.Save();
                }
            }
        }
    }


    public void ChangeKey()
    {
        buttonLabel.text = "Press a key...";
    }
}
