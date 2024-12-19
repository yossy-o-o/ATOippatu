using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider bGMSlider;

    [SerializeField] Slider sESlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioSetting();
    }

    void Update()
    {
        Debug.Log($"AudioSource Volume: {(audioMixer.GetFloat("BGM_Volume", out float volume) ? volume : -1)}");
    }


    private void AudioSetting()
    {
        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        bGMSlider.value = bgmVolume;

        audioMixer.GetFloat("SE_Volume", out float sEVolume);
        sESlider.value = sEVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE_Volume", volume);
    }
}
