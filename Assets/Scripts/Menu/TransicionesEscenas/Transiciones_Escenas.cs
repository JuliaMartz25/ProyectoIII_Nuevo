using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones_Escenas : MonoBehaviour
{
    public int numeroEscena;

    public void _cargarEscena()
    {
        SceneManager.LoadScene(numeroEscena);
    }

    public void destroyCanvas()
    {
        Destroy(this.gameObject);
    }
}