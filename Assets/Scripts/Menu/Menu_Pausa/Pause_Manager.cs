using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Manager : MonoBehaviour
{
    public GameObject _pausa, _opciones, _salir, fondoTransparente, botonPausa;
    public bool pausa_, opciones_, salir_;
    public AudioSource _sonidoBoton, _cerrarMenu;
    public int escenaGuardada;

    void Start()
    {
        pausa_ = false;
        opciones_ = false;
        salir_ = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausa_ && !opciones_ && !salir_)
        {
            pausar();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausa_)
        {
            continuar();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && opciones_)
        {
            salirOpciones();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && salir_)
        {
            salirSalir();
        }
    }

    public void pausar()
    {
        _pausa.SetActive(true);
        fondoTransparente.SetActive(true);
        Time.timeScale = 0;
        pausa_ = true;
        botonPausa.SetActive(false);
        _cerrarMenu.Play();
    }

    public void continuar()
    {
        _pausa.SetActive(false);
        fondoTransparente.SetActive(false);
        Time.timeScale = 1;
        pausa_ = false;
        botonPausa.SetActive(true);
        _cerrarMenu.Play();
    }

    public void options()
    {
        _opciones.SetActive(true);
        _pausa.SetActive(false);
        pausa_ = false;
        opciones_ = true;
        _sonidoBoton.Play();
    }

    public void salirOpciones()
    {
        _opciones.SetActive(false);
        _pausa.SetActive(true);
        pausa_ = true;
        opciones_ = false;
        _sonidoBoton.Play();
    }

    public void Salir()
    {
        _salir.SetActive(true);
        _pausa.SetActive(false);
        pausa_ = false;
        salir_ = true;
        _sonidoBoton.Play();
    }

    public void salirSalir()
    {
        _salir.SetActive(false);
        _pausa.SetActive(true);
        pausa_ = true;
        salir_ = false;
        _sonidoBoton.Play();
    }

    public void salirMenuGuardar()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("PartidaGuardada", escenaGuardada);
        //SceneManager.LoadScene(0);
        Application.Quit();
        _sonidoBoton.Play();
    }

    public void salirMenuNoGuardar()
    {
        Time.timeScale = 1;
        //SceneManager.LoadScene(0);
        Application.Quit();
        _sonidoBoton.Play();
    }
}