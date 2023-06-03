using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sonido : MonoBehaviour
{
    public AudioMixer mixerMusic, mixerEffects, mixerDialogo;
    public Slider sliderMusic, sliderEffects, sliderDialogo;
    public GameObject Graficos, Audio, MuteMusic, UnmuteMusic, MuteEffects, UnmuteEffects, MuteDialogo, UnmuteDialogo, imagen_1, imagen_2;
    float valorMusic, valorEffects, valorDialogo, valor_anterior_musica, valor_anterior_effects, valor_anterior_dialogo;
    [SerializeField] Text Music_Text, Effects_Text, Dialogo_Text;

    void Start()
    {
        if (PlayerPrefs.GetInt("EmpezarVolumen") == 0)
        {
            sliderMusic.value = 1;
            sliderEffects.value = 1;
            sliderDialogo.value = 1;
            mixerMusic.SetFloat("Mixer_Music_Volume", 0);
            mixerEffects.SetFloat("Mixer_Effects_Volume", 0);
            mixerEffects.SetFloat("Mixer_Effects_Dialogo", 0);
            PlayerPrefs.SetInt("EmpezarVolumen", 1);
        }
        else if (PlayerPrefs.GetInt("EmpezarVolumen") == 1)
        {
            sliderMusic.value = PlayerPrefs.GetFloat("VolumenMusic");
            sliderEffects.value = PlayerPrefs.GetFloat("VolumenEffects");
            sliderDialogo.value = PlayerPrefs.GetFloat("VolumenDialogo");
            mixerMusic.SetFloat("Mixer_Music_Volume", Mathf.Log10(sliderMusic.value) * 20);
            mixerEffects.SetFloat("Mixer_Effects_Volume", Mathf.Log10(sliderEffects.value) * 20);
            mixerEffects.SetFloat("Mixer_Effects_Dialogo", Mathf.Log10(sliderEffects.value) * 20);
        }
    }

    void Update()
    {
        valorMusic = sliderMusic.value * 100;
        valorEffects = sliderEffects.value * 100;
        valorDialogo = sliderDialogo.value * 100;
        Music_Text.text = valorMusic.ToString("0");
        Effects_Text.text = valorEffects.ToString("0");
        Dialogo_Text.text = valorDialogo.ToString("0");

        if (sliderMusic.value > 0)
        {
            MuteMusic.SetActive(false);
            UnmuteMusic.SetActive(true);
            PlayerPrefs.SetFloat("VolumenMusic", sliderMusic.value);
        }
        if (sliderMusic.value == 0)
        {
            MuteMusic.SetActive(true);
            UnmuteMusic.SetActive(false);
            mixerMusic.SetFloat("Mixer_Music_Volume", -60);
            PlayerPrefs.SetFloat("VolumenMusic", sliderMusic.value);
        }

        if (sliderEffects.value > 0)
        {
            MuteEffects.SetActive(false);
            UnmuteEffects.SetActive(true);
            PlayerPrefs.SetFloat("VolumenEffects", sliderEffects.value);
        }
        if (sliderEffects.value == 0)
        {
            MuteEffects.SetActive(true);
            UnmuteEffects.SetActive(false);
            mixerEffects.SetFloat("Mixer_Effects_Volume", -60);
            PlayerPrefs.SetFloat("VolumenEffects", sliderEffects.value);
        }

        if (sliderDialogo.value > 0)
        {
            MuteDialogo.SetActive(false);
            UnmuteDialogo.SetActive(true);
            PlayerPrefs.SetFloat("VolumenDialogo", sliderDialogo.value);
        }
        if (sliderDialogo.value == 0)
        {
            MuteDialogo.SetActive(true);
            UnmuteDialogo.SetActive(false);
            mixerDialogo.SetFloat("Mixer_Effects_Dialogo", -60);
            PlayerPrefs.SetFloat("VolumenDialogo", sliderDialogo.value);
        }
    }

    public void SetVolume_Music(float volumeMusic)
    {
        mixerMusic.SetFloat("Mixer_Music_Volume", Mathf.Log10(volumeMusic) * 20);
    }

    public void SetVolume_Effects(float volumeEffects)
    {
        mixerEffects.SetFloat("Mixer_Effects_Volume", Mathf.Log10(volumeEffects) * 20);
    }

    public void SetVolume_Dialogo(float volumeDialogo)
    {
        mixerDialogo.SetFloat("Mixer_Effects_Dialogo", Mathf.Log10(volumeDialogo) * 20);
    }

    public void MutearMusic()
    {
        valor_anterior_musica = sliderMusic.value;
        sliderMusic.value = 0;
    }
    public void DesmutearMusic()
    {
        sliderMusic.value = valor_anterior_musica;
    }

    public void MutearEffects()
    {
        valor_anterior_effects = sliderEffects.value;
        sliderEffects.value = 0;
    }
    public void DesmutearEffects()
    {
        sliderEffects.value = valor_anterior_effects;
    }

    public void MutearDialogo()
    {
        valor_anterior_dialogo = sliderDialogo.value;
        sliderDialogo.value = 0;
    }

    public void DesmutearDialogo()
    {
        sliderDialogo.value = valor_anterior_dialogo;
    }

    public void graficos()
    {
        Graficos.SetActive(true);
        Audio.SetActive(false);
        imagen_1.SetActive(false);
        imagen_2.SetActive(true);
    }

    public void _audio()
    {
        Graficos.SetActive(false);
        Audio.SetActive(true);
        imagen_1.SetActive(true);
        imagen_2.SetActive(false);
    }
}