using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider1 : MonoBehaviour
{
    public AudioSource AudioSource;

    public Slider volumeSlider;

    private float MusicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }
    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }
}
