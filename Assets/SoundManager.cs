using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public bool playSound = true;

    private void Update()
    {
        if (!playSound && !GetComponent<AudioSource>().mute)
        {
            GetComponent<AudioSource>().mute = true;
        }

        if (playSound && GetComponent<AudioSource>().mute)
        {
            GetComponent<AudioSource>().mute = false;
        }
    }

    public void ChangeMute()
    {
        if (playSound)
        {
            playSound = false;
        }
        else
        {
            playSound = true;
        }
    }
}