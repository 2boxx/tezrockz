using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider sliderAudioMusic;
    public Slider sliderAudioFX;

    public AudioMixer audioMixerGame;


   [Header("Icon Volume Music")]
    public Image IconMusic;
    public Sprite IconMusicOn;
    public Sprite IconMusicOff;
    
    [Header("Icon Volume FX")]
    public Image IconFX;
    public Sprite IconFXOn;
    public Sprite IconFXOff;

    private void Start()
    {
        UpdateMusicVolume();
        UpdateFXVolume();
    }

    public void UpdateMusicVolume()
    {
        float minValueMixer = -80f;
        float maxValueMixer = 0f;
        var scaledValue = minValueMixer + (sliderAudioMusic.value - 0) * (maxValueMixer - minValueMixer) / (1 - 0);
        audioMixerGame.SetFloat("MusicVolume", scaledValue);
      
        if (sliderAudioMusic.value <= 0)
        {
            IconMusic.sprite = IconMusicOff;
        }
        else
        {
            IconMusic.sprite = IconMusicOn;
        }
    }
    
    public void UpdateFXVolume()
    {
        float minValueMixer = -80f;
        float maxValueMixer = 0f;

        var scaledValue = minValueMixer + (sliderAudioFX.value - 0) * (maxValueMixer - minValueMixer) / (1- 0);
        audioMixerGame.SetFloat("FXVolume", scaledValue);


        if (sliderAudioFX.value <= 0)
        {
            IconFX.sprite = IconFXOff;
        }
        else
        {
            IconFX.sprite = IconFXOn;
        }

    }
    
    
   
}
