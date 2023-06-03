using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI tiempoTexto;
    public float tiempo = 0.1f;

    public GameObject Boton;
    public GameObject TimerScene;
    public GameObject preparate, exclamacion;


    public GameObject Enemigos;
    public GameObject Collider;

    public GameObject PuntoMov;

    private bool Empezar = false;

    public void Update()
    {
        if(Empezar)
        {
            tiempo -= Time.deltaTime;
            tiempoTexto.text = "" + tiempo.ToString("f0");
        }

        if(tiempo <= 0)
        {
            Empezar = false;
            Destroy(TimerScene);
            Enemigos.SetActive(true);
            Collider.SetActive(true);
        }
    }

    public void EmpezarTemporizador()
    {
        StartCoroutine("Preparate");
        Destroy(Boton);
    }

    private IEnumerator Preparate()
    {
        preparate.SetActive(true);
        exclamacion.SetActive(true);
        yield return new WaitForSeconds(2f);
        TimerScene.SetActive(true);
        PuntoMov.SetActive(true);
        Empezar = true;
        PlayerFollow.Comenzar = true;
        Destroy(preparate);
        Destroy(exclamacion);
    }

}
