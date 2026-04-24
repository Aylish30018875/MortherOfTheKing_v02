using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        //if the instance doesn't exist
        if (instance == null)
        {
            //then the instance is this
            instance = this;
        }
        //otherwise if the instance does exist and it isn't this
        else if (instance != null && instance != this)
        {
            //destroy it
            Destroy(instance.gameObject);
        }
        //keep the audio manager alive when loading between scenes
        DontDestroyOnLoad(instance.gameObject);
    }
}
