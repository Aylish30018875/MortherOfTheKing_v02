using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager instance;
    public AudioSource clickAudio;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
