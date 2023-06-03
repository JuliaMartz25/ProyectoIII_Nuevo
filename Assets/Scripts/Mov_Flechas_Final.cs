using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Mov_Flechas_Final : MonoBehaviour
{
    public Vector3 LimiteMax, LimiteMin;
    [Range(0, 100)]
    public float ValorMedidor;
    public float cambioMedidor;
    public GameObject _medidor;

    public ObjectiveManager objectiveManager;

    public TextMeshProUGUI porcentajeMedidor;

    public static int nivelActual = 0;

    public static Color noAlphaColor;
    public static Color siAlphaColor;

    /*void Awake()
    {
        switch (nivelActual)
        {
            case 0:
            ValorMedidor = 50;
            break;

            case 1:
            ValorMedidor = 30;
            break;

            case 2:
            ValorMedidor = 20;
            break;

            case 3:
            ValorMedidor = 10;
            break;
        }
        
        ComprobColMedidor();
        print("awake start mov flechas");
    }*/
    
    void Start()
    {
        noAlphaColor = new Color(1f, 1f, 1f, 0f);
        siAlphaColor = new Color(1f, 1f, 1f, 1f);
        
        switch (nivelActual)
        {
            case 0:
            ValorMedidor = 50;
            break;

            case 1:
            ValorMedidor = 30;
            break;

            case 2:
            ValorMedidor = 20;
            break;

            case 3:
            ValorMedidor = 10;
            break;
        }
        
        ComprobColMedidor();
        print("start base mov flechas");
        
    }

    void Update()
    {
        print("start nivel actual " + nivelActual);
        print("start valor medidor " + ValorMedidor);
        Vector3 valor_Felicidad = Vector3.Lerp(LimiteMax, LimiteMin, ValorMedidor / 100f);
        _medidor.transform.position = valor_Felicidad;
        porcentajeMedidor.text = (ValorMedidor + "%");


    }

    IEnumerator ModifMedidor()
    {
        switch (cambioMedidor)
        {
            case 10:
            case -10:
            for (int i = 0; i < 10; i++)
            {
                ValorMedidor += (cambioMedidor / 10);
                yield return new WaitForSeconds(0.2f);
            }
            break;

            case 15:
            case -15:
            for (int i = 0; i < 15; i++)
            {
                ValorMedidor += (cambioMedidor / 15);
                yield return new WaitForSeconds(0.133f);
            }
            break;

            case 20:
            case -20:
            for (int i = 0; i < 20; i++)
            {
                ValorMedidor += (cambioMedidor / 20);
                yield return new WaitForSeconds(0.1f);
            }
            break;

            case 25:
            case -25:
            for (int i = 0; i < 25; i++)
            {
                ValorMedidor += (cambioMedidor / 25);
                yield return new WaitForSeconds(0.08f);
            }
            break;

            case 5:
            case -5:
                for (int i = 0; i < 5; i++)
                {
                    ValorMedidor += (cambioMedidor / 5);
                    yield return new WaitForSeconds(0.4f);
                }
                break;

            case 4:
            case -4:
                for (int i = 0; i < 4; i++)
                {
                    ValorMedidor += (cambioMedidor / 4);
                    yield return new WaitForSeconds(0.5f);
                }
                break;

            case 3:
            case -3:
                for (int i = 0; i < 3; i++)
                {
                    ValorMedidor += (cambioMedidor / 3);
                    yield return new WaitForSeconds(0.666f);
                }
                break;

            case 2:
            case -2:
                for (int i = 0; i < 2; i++)
                {
                    ValorMedidor += (cambioMedidor / 2);
                    yield return new WaitForSeconds(1f);
                }
                break;

            case 1:
            case -1:
                for (int i = 0; i < 1; i++)
                {
                    ValorMedidor += (cambioMedidor / 1);
                    yield return new WaitForSeconds(2f);
                }
                break;
        }

        ComprobColMedidor();
    }
    public void ComprobColMedidor()
    {
        switch (ValorMedidor)
        {
            case 0:
            porcentajeMedidor.color = Color.black;
            break;

            case 5:
            case 10:
            case 15:
            case 19:
            porcentajeMedidor.color = Color.grey;
            break;

            case 20:
            case 25:
            case 30:
            case 35:
            case 39:
            porcentajeMedidor.color = objectiveManager.colorMinimapa[3];
            break;

            case 40:
            case 45:
            case 50:
            case 55:
            case 59:
            porcentajeMedidor.color = objectiveManager.colorMinimapa[2];
            break;

            case 60:
            case 65:
            case 70:
            case 75:
            case 79:
            porcentajeMedidor.color = objectiveManager.colorMinimapa[1];
            break;

            case 80:
            case 81:
            case 82:
            case 83:
            case 84:
            case 85:
            case 86:
            case 87:
            case 88:
            case 89:
            case 90:
            case 91:
            case 92:
            case 93:
            case 94:
            case 95:
            porcentajeMedidor.color = objectiveManager.colorMinimapa[0];
            break;

            case 100:
            case 101:
            case 102:
            case 103:
            case 104:
            case 105:
            case 110:
            case 115:
            case 120:
            porcentajeMedidor.color = Color.white;
            break;
        }
    }
}
