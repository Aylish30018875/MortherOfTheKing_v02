using UnityEngine;

public class SpawnAudioManager : MonoBehaviour
{
    public GameObject audioManagerRef;
    void Start()
    {
        //if there is no audio manager (object taggedwith "AudioManager")
        if (!GameObject.FindWithTag("AudioManager"))
        {
            //spawn one
            Instantiate(audioManagerRef);
        }
    }


}
