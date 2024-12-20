using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;

    private void Start()
    {

        audioMixer.GetFloat("BGM", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE", out float seVolume);
        sESlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }


}