using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizacion_Personaje_Escena : MonoBehaviour
{
    public GameObject gafasEstrella, gafasRedondas, collarFlor, collarPerlas, gorra, coronaAzul, coronaMorada, coronaVerde, coronaRoja,
        coronaAmarilla, sombreroAzul, sombreroRojo, sombreroVerde, sombreroAmarillo, sombreroMorado;
    public GameObject[] colorO, colorV, colorR, colorA, colorM;

    void Start()
    {
        #region complementosFalse
        gafasEstrella.SetActive(false);
        gafasRedondas.SetActive(false);
        collarFlor.SetActive(false);
        collarPerlas.SetActive(false);
        gorra.SetActive(false);
        coronaAzul.SetActive(false);
        coronaMorada.SetActive(false);
        coronaVerde.SetActive(false);
        coronaRoja.SetActive(false);
        coronaAmarilla.SetActive(false);
        sombreroAzul.SetActive(false);
        sombreroRojo.SetActive(false);
        sombreroVerde.SetActive(false);
        sombreroAmarillo.SetActive(false);
        sombreroMorado.SetActive(false);
        #endregion

        #region complementos
        /*if (PlayerPrefs.GetInt("Complemento") == 0)
        {
            //texto_complemento.text = "Sin complemento";
        }*/
        if (PlayerPrefs.GetInt("Complemento") == 1)
        {
            gafasEstrella.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 2)
        {
            gafasRedondas.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 3)
        {
            collarFlor.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 4)
        {
            collarPerlas.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 5)
        {
            gorra.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 6)
        {
            coronaAzul.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 7)
        {
            coronaMorada.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 8)
        {
            coronaVerde.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 9)
        {
            coronaRoja.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 10)
        {
            coronaAmarilla.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 11)
        {
            sombreroAzul.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 12)
        {
            sombreroRojo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 13)
        {
            sombreroVerde.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 14)
        {
            sombreroAmarillo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 15)
        {
            sombreroMorado.SetActive(true);
        }
        #endregion

        #region colorFalse
        colorO[0].SetActive(false);
        colorO[1].SetActive(false);
        colorO[2].SetActive(false);
        colorO[3].SetActive(false);
        colorO[4].SetActive(false);

        colorV[0].SetActive(false);
        colorV[1].SetActive(false);
        colorV[2].SetActive(false);
        colorV[3].SetActive(false);
        colorV[4].SetActive(false);

        colorR[0].SetActive(false);
        colorR[1].SetActive(false);
        colorR[2].SetActive(false);
        colorR[3].SetActive(false);
        colorR[4].SetActive(false);

        colorA[0].SetActive(false);
        colorA[1].SetActive(false);
        colorA[2].SetActive(false);
        colorA[3].SetActive(false);
        colorA[4].SetActive(false);

        colorM[0].SetActive(false);
        colorM[1].SetActive(false);
        colorM[2].SetActive(false);
        colorM[3].SetActive(false);
        colorM[4].SetActive(false);
        #endregion

        if (PlayerPrefs.GetInt("Color") == 0)
        {
            colorO[0].SetActive(true);
            colorO[1].SetActive(true);
            colorO[2].SetActive(true);
            colorO[3].SetActive(true);
            colorO[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 1)
        {
            colorV[0].SetActive(true);
            colorV[1].SetActive(true);
            colorV[2].SetActive(true);
            colorV[3].SetActive(true);
            colorV[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 2)
        {
            colorR[0].SetActive(true);
            colorR[1].SetActive(true);
            colorR[2].SetActive(true);
            colorR[3].SetActive(true);
            colorR[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 3)
        {
            colorA[0].SetActive(true);
            colorA[1].SetActive(true);
            colorA[2].SetActive(true);
            colorA[3].SetActive(true);
            colorA[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 4)
        {
            colorM[0].SetActive(true);
            colorM[1].SetActive(true);
            colorM[2].SetActive(true);
            colorM[3].SetActive(true);
            colorM[4].SetActive(true);
        }
    }
}