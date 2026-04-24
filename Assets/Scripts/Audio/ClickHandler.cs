using UnityEngine;

public class ClickHandler : MonoBehaviour
{

public void MakeClickSound(AudioClip soundToPlay)
    {
        if(ClickManager.instance != null)
        {
            ClickManager.instance.clickAudio.PlayOneShot(soundToPlay);
        }
    }
}
