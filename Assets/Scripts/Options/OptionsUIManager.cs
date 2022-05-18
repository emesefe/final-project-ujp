using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUIManager : MonoBehaviour
{
    [SerializeField] private Toggle music, sfx;
    [SerializeField] private Slider musicVolume, sfxVolume;

    private AudioSource musicAS;
    private float maxMusicVolume;

    private void Start()
    {
        musicAS = FindObjectOfType<AudioSource>();

        musicVolume.value = PersistentData.musicVolume;
        music.isOn = PersistentData.musicOn;
        
        sfxVolume.value = PersistentData.sfxVolume;
        sfx.isOn = PersistentData.sfxOn;
    }

    public void UpdateMusicVolume(float volume)
    {
        musicAS.volume = volume;
        PersistentData.musicVolume = volume;
    }
    
    public void ToggleMusic(bool active)
    {
        musicAS.mute = !active;
        PersistentData.musicOn = active;
        
        musicVolume.interactable = active;
    }
    
    public void UpdateSFXVolume(float volume)
    {
        PersistentData.sfxVolume = volume;
    }
    
    public void ToggleSFX(bool active)
    {
        PersistentData.sfxOn = active;
        sfxVolume.interactable = active;
    }
}
