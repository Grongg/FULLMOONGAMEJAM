using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer; // The audio mixer that we use to handle music volume

    public void SetLevel(float sliderValue) // set the volume of the music
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    // mute option 

    public GameObject MuteOn;
    public GameObject MuteOff;
    public bool activateme;

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
        if (MuteOn.activeSelf)
            MuteOn.SetActive(false);
        else
            MuteOn.SetActive(true);

        if (MuteOff.activeSelf)
            MuteOff.SetActive(false);
        else
            MuteOff.SetActive(true);


    }

}
