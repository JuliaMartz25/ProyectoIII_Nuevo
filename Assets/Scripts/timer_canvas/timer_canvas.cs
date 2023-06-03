using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer_canvas : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto;
    public TextMeshProUGUI textoObjeto;
    public GameObject _texto;

    private bool Empezar, mostrarTexto, segundavinetaMostrada;


    public void Destruir_boton()
    {
        tiempoTexto.gameObject.SetActive(false);
    }

    private void MostrarTexto()
    {
        textoObjeto.gameObject.SetActive(true);
    }

    private void OcultarTexto()
    {
        textoObjeto.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _texto.SetActive(false);
        }
    }

    public void MostrarSegundaVineta()
    {
        // Llamado desde otro lugar para mostrar la segunda viñeta
        segundavinetaMostrada = true;
    }
}
