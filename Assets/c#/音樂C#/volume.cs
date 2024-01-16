using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class volume : MonoBehaviour
{

    public  AudioMixer audioMixer;
   
    public  void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public  void BGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }
    public  void KeyDownVolume(float volume)
    {
        audioMixer.SetFloat("KeyDownVolume", volume);
    }

    
   
}
