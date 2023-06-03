using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graficos : MonoBehaviour
{
    public int int_FPS, int_Resolucion, _vSync;
    public bool bool_FPS;
    public GameObject _audio, _graficos, fps_GO, imagenBrillo1, imagenBrillo2, imagenBrillo3, imagenBrillo4;
    public Text textoMostrarFPS, textoFPS, textoResolucion, texto_VSync;
    public Toggle toggle_FullScreen;
    public Button botonDfps, botonIfps;
    public Slider sliderBrillo;
    public Image panelBrillo;

    void Start()
    {
        if (PlayerPrefs.GetInt("Mostrar_FPS") == 0)
        {
            fps_GO.SetActive(false);
            bool_FPS = false;
            textoMostrarFPS.text = "No mostrar FPS";
        }
        else if (PlayerPrefs.GetInt("Mostrar_FPS") == 1)
        {
            fps_GO.SetActive(true);
            bool_FPS = true;
            textoMostrarFPS.text = "Mostrar FPS";
        }

        if (Screen.fullScreen)
        {
            toggle_FullScreen.isOn = true;
        }
        else
        {
            toggle_FullScreen.isOn = false;
        }

        if (PlayerPrefs.GetInt("PP_Res") == 0)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
            textoResolucion.text = "1920 x 1080";
            int_Resolucion = 0;
        }
        else if (PlayerPrefs.GetInt("PP_Res") == 1)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(2560, 1440, true);
            }
            else
            {
                Screen.SetResolution(2560, 1440, false);
            }
            textoResolucion.text = "2560 x 1440";
            int_Resolucion = 1;
        }
        else if (PlayerPrefs.GetInt("PP_Res") == 2)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(3840, 2160, true);
            }
            else
            {
                Screen.SetResolution(3840, 2160, false);
            }
            textoResolucion.text = "3840 x 2160";
            int_Resolucion = 2;
        }
        else if (PlayerPrefs.GetInt("PP_Res") == 3)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(640, 360, true);
            }
            else
            {
                Screen.SetResolution(640, 360, false);
            }
            textoResolucion.text = "640 x 360";
            int_Resolucion = 3;
        }
        else if (PlayerPrefs.GetInt("PP_Res") == 4)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(896, 504, true);
            }
            else
            {
                Screen.SetResolution(896, 504, false);
            }
            textoResolucion.text = "896 x 504";
            int_Resolucion = 4;
        }
        else if (PlayerPrefs.GetInt("PP_Res") == 5)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
            textoResolucion.text = "1280 x 720";
            int_Resolucion = 5;
        }

        if (PlayerPrefs.GetInt("PP_FPS") == 0)
        {
            Application.targetFrameRate = 30;
            textoFPS.text = "30 FPS";
            int_FPS = 0;
        }
        else if (PlayerPrefs.GetInt("PP_FPS") == 1)
        {
            Application.targetFrameRate = 60;
            textoFPS.text = "60 FPS";
            int_FPS = 1;
        }
        else if (PlayerPrefs.GetInt("PP_FPS") == 2)
        {
            Application.targetFrameRate = 120;
            textoFPS.text = "120 FPS";
            int_FPS = 2;
        }
        else if (PlayerPrefs.GetInt("PP_FPS") == 3)
        {
            Application.targetFrameRate = 240;
            textoFPS.text = "240 FPS";
            int_FPS = 3;
        }

        if (PlayerPrefs.GetInt("PP_vSync") == 0)
        {
            _vSync = 0;
            QualitySettings.vSyncCount = 0;
            texto_VSync.text = "ON";
            botonDfps.interactable = true;
            botonIfps.interactable = true;
        }
        else if (PlayerPrefs.GetInt("PP_vSync") == 1)
        {
            _vSync = 1;
            QualitySettings.vSyncCount = 1;
            texto_VSync.text = "OFF";
            botonDfps.interactable = false;
            botonIfps.interactable = false;
        }

        sliderBrillo.value = PlayerPrefs.GetFloat("PP_Brillo");
        panelBrillo.color = new Color(0, 0, 0, sliderBrillo.value);
    }

    void Update()
    {
        if (sliderBrillo.value >= 0 && sliderBrillo.value < 0.25)
        {
            imagenBrillo1.SetActive(true);
            imagenBrillo2.SetActive(false);
            imagenBrillo3.SetActive(false);
            imagenBrillo4.SetActive(false);
        }
        if (sliderBrillo.value >= 0.25 && sliderBrillo.value < 0.5)
        {
            imagenBrillo1.SetActive(false);
            imagenBrillo2.SetActive(true);
            imagenBrillo3.SetActive(false);
            imagenBrillo4.SetActive(false);
        }
        if (sliderBrillo.value >= 0.5 && sliderBrillo.value < 0.75)
        {
            imagenBrillo1.SetActive(false);
            imagenBrillo2.SetActive(false);
            imagenBrillo3.SetActive(true);
            imagenBrillo4.SetActive(false);
        }
        if (sliderBrillo.value == 0.75)
        {
            imagenBrillo1.SetActive(false);
            imagenBrillo2.SetActive(false);
            imagenBrillo3.SetActive(false);
            imagenBrillo4.SetActive(true);
        }
    }

    public void BotonDerechaResolucion()
    {
        if (int_Resolucion == 3)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(896, 504, true);
            }
            else
            {
                Screen.SetResolution(896, 504, false);
            }
            textoResolucion.text = "896 x 504";
            int_Resolucion = 4;
            PlayerPrefs.SetInt("PP_Res", 4);
        }
        else if (int_Resolucion == 4)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
            textoResolucion.text = "1280 x 720";
            int_Resolucion = 5;
            PlayerPrefs.SetInt("PP_Res", 5);
        }
        else if (int_Resolucion == 5)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
            textoResolucion.text = "1920 x 1080";
            int_Resolucion = 0;
            PlayerPrefs.SetInt("PP_Res", 0);
        }
        else if (int_Resolucion == 0)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(2560, 1440, true);
            }
            else
            {
                Screen.SetResolution(2560, 1440, false);
            }
            textoResolucion.text = "2560 x 1440";
            int_Resolucion = 1;
            PlayerPrefs.SetInt("PP_Res", 1);
        }
        else if (int_Resolucion == 1)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(3840, 2160, true);
            }
            else
            {
                Screen.SetResolution(3840, 2160, false);
            }
            textoResolucion.text = "3840 x 2160";
            int_Resolucion = 2;
            PlayerPrefs.SetInt("PP_Res", 2);
        }
        else if (int_Resolucion == 2)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(640, 360, true);
            }
            else
            {
                Screen.SetResolution(640, 360, false);
            }
            textoResolucion.text = "640 x 360";
            int_Resolucion = 3;
            PlayerPrefs.SetInt("PP_Res", 3);
        }
    }

    public void BotonIzquierdaResolucion()
    {
        if (int_Resolucion == 3)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(3840, 2160, true);
            }
            else
            {
                Screen.SetResolution(3840, 2160, false);
            }
            textoResolucion.text = "3840 x 2160";
            int_Resolucion = 2;
            PlayerPrefs.SetInt("PP_Res", 2);
        }
        else if (int_Resolucion == 4)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(640, 360, true);
            }
            else
            {
                Screen.SetResolution(640, 360, false);
            }
            textoResolucion.text = "640 x 360";
            int_Resolucion = 3;
            PlayerPrefs.SetInt("PP_Res", 3);
        }
        else if (int_Resolucion == 5)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(896, 504, true);
            }
            else
            {
                Screen.SetResolution(896, 504, false);
            }
            textoResolucion.text = "896 x 504";
            int_Resolucion = 4;
            PlayerPrefs.SetInt("PP_Res", 4);
        }
        else if (int_Resolucion == 0)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
            textoResolucion.text = "1280 x 720";
            int_Resolucion = 5;
            PlayerPrefs.SetInt("PP_Res", 5);
        }
        else if (int_Resolucion == 1)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
            textoResolucion.text = "1920 x 1080";
            int_Resolucion = 0;
            PlayerPrefs.SetInt("PP_Res", 0);
        }
        else if (int_Resolucion == 2)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(2560, 1440, true);
            }
            else
            {
                Screen.SetResolution(2560, 1440, false);
            }
            textoResolucion.text = "2560 x 1440";
            int_Resolucion = 1;
            PlayerPrefs.SetInt("PP_Res", 1);
        }
    }

    public void MostrarFPS()
    {
        if (bool_FPS)
        {
            fps_GO.SetActive(false);
            bool_FPS = false;
            textoMostrarFPS.text = "No mostrar FPS";
            PlayerPrefs.SetInt("Mostrar_FPS", 0);
        }
        else if (!bool_FPS)
        {
            fps_GO.SetActive(true);
            bool_FPS = true;
            textoMostrarFPS.text = "Mostrar FPS";
            PlayerPrefs.SetInt("Mostrar_FPS", 1);
        }
    }

    public void BotonDerechaFPS()
    {
        if (int_FPS == 0)
        {
            Application.targetFrameRate = 60;
            textoFPS.text = "60 FPS";
            int_FPS = 1;
            PlayerPrefs.SetInt("PP_FPS", 1);
        }
        else if (int_FPS == 1)
        {
            Application.targetFrameRate = 120;
            textoFPS.text = "120 FPS";
            int_FPS = 2;
            PlayerPrefs.SetInt("PP_FPS", 2);
        }
        else if (int_FPS == 2)
        {
            Application.targetFrameRate = 240;
            textoFPS.text = "240 FPS";
            int_FPS = 3;
            PlayerPrefs.SetInt("PP_FPS", 3);
        }
        else if (int_FPS == 3)
        {
            Application.targetFrameRate = 30;
            textoFPS.text = "30 FPS";
            int_FPS = 0;
            PlayerPrefs.SetInt("PP_FPS", 0);
        }
    }

    public void BotonIzquierdaFPS()
    {
        if (int_FPS == 0)
        {
            Application.targetFrameRate = 240;
            textoFPS.text = "240 FPS";
            int_FPS = 3;
            PlayerPrefs.SetInt("PP_FPS", 3);
        }
        else if (int_FPS == 1)
        {
            Application.targetFrameRate = 30;
            textoFPS.text = "30 FPS";
            int_FPS = 0;
            PlayerPrefs.SetInt("PP_FPS", 0);
        }
        else if (int_FPS == 2)
        {
            Application.targetFrameRate = 60;
            textoFPS.text = "60 FPS";
            int_FPS = 1;
            PlayerPrefs.SetInt("PP_FPS", 1);
        }
        else if (int_FPS == 3)
        {
            Application.targetFrameRate = 120;
            textoFPS.text = "120 FPS";
            int_FPS = 2;
            PlayerPrefs.SetInt("PP_FPS", 2);
        }
    }

    public void PantallaCompleta(bool _pantalla)
    {
        Screen.fullScreen = _pantalla;
    }

    public void Boton_VSync()
    {
        if (_vSync == 0)
        {
            texto_VSync.text = "OFF";
            _vSync = 1;
            QualitySettings.vSyncCount = 1;
            botonDfps.interactable = false;
            botonIfps.interactable = false;
            //fps limitados por el juego
            PlayerPrefs.SetInt("PP_vSync", 1);
        }
        else if (_vSync == 1)
        {
            texto_VSync.text = "ON";
            _vSync = 0;
            QualitySettings.vSyncCount = 0;
            botonDfps.interactable = true;
            botonIfps.interactable = true;
            //fps limitados por el pc
            PlayerPrefs.SetInt("PP_vSync", 0);
        }
    }

    public void SliderBrillo(float valor)
    {
        panelBrillo.color = new Color(0, 0, 0, sliderBrillo.value);
        PlayerPrefs.SetFloat("PP_Brillo", sliderBrillo.value);
    }
}