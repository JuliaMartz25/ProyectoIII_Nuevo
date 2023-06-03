using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personalizacion_Personaje : MonoBehaviour
{
    public Text texto_complemento, texto_color, texto_complemento2, texto_color2;
    public GameObject gafasEstrella, gafasRedondas, collarFlor, collarPerlas, gorra, coronaAzul, coronaMorada, coronaVerde, coronaRoja,
        coronaAmarilla, sombreroAzul, sombreroRojo, sombreroVerde, sombreroAmarillo, sombreroMorado, sigVineta1, sigVineta2, perso1, perso2,
        vineFija1, vineFija2, vineFija3, _bot;
    public int complemento, color, complementoInicial, colorInicial, maximoCaracteres;
    public static string longString;
    public Text textoNombre;
    public InputField inputText;
    public bool _personalizacion, muestroPlayer;
    public GameObject[] colorO, colorV, colorR, colorA, colorM, listaVinetas;
    public Transform P1, P2;

    void Start()
    {
        _personalizacion = false;
        complementoInicial = PlayerPrefs.GetInt("Complemento");
        complemento = PlayerPrefs.GetInt("Complemento");
        colorInicial = PlayerPrefs.GetInt("Color");
        color = PlayerPrefs.GetInt("Color");

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
        if (PlayerPrefs.GetInt("Complemento") == 0)
        {
            texto_complemento.text = "Sin complemento";
        }
        if (PlayerPrefs.GetInt("Complemento") == 1)
        {
            texto_complemento.text = "Gafas Estrella";
            gafasEstrella.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 2)
        {
            texto_complemento.text = "Gafas";
            gafasRedondas.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 3)
        {
            texto_complemento.text = "Collar Flor";
            collarFlor.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 4)
        {
            texto_complemento.text = "Collar Perlas";
            collarPerlas.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 5)
        {
            texto_complemento.text = "Gorra";
            gorra.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 6)
        {
            texto_complemento.text = "Corona Azul";
            coronaAzul.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 7)
        {
            texto_complemento.text = "Corona Morada";
            coronaMorada.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 8)
        {
            texto_complemento.text = "Corona Verde";
            coronaVerde.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 9)
        {
            texto_complemento.text = "Corona Roja";
            coronaRoja.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 10)
        {
            texto_complemento.text = "Corona Amarilla";
            coronaAmarilla.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 11)
        {
            texto_complemento.text = "Sombrero Azul";
            sombreroAzul.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 12)
        {
            texto_complemento.text = "Sombrero Rojo";
            sombreroRojo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 13)
        {
            texto_complemento.text = "Sombrero Verde";
            sombreroVerde.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 14)
        {
            texto_complemento.text = "Sombrero Amarillo";
            sombreroAmarillo.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complemento") == 15)
        {
            texto_complemento.text = "Sombrero Morado";
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
            texto_color.text = "Color Original";
            colorO[0].SetActive(true);
            colorO[1].SetActive(true);
            colorO[2].SetActive(true);
            colorO[3].SetActive(true);
            colorO[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 1)
        {
            texto_color.text = "Color Verde";
            colorV[0].SetActive(true);
            colorV[1].SetActive(true);
            colorV[2].SetActive(true);
            colorV[3].SetActive(true);
            colorV[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 2)
        {
            texto_color.text = "Color Rojo";
            colorR[0].SetActive(true);
            colorR[1].SetActive(true);
            colorR[2].SetActive(true);
            colorR[3].SetActive(true);
            colorR[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 3)
        {
            texto_color.text = "Color Amarillo";
            colorA[0].SetActive(true);
            colorA[1].SetActive(true);
            colorA[2].SetActive(true);
            colorA[3].SetActive(true);
            colorA[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Color") == 4)
        {
            texto_color.text = "Color Morado";
            colorM[0].SetActive(true);
            colorM[1].SetActive(true);
            colorM[2].SetActive(true);
            colorM[3].SetActive(true);
            colorM[4].SetActive(true);
        }
    }

    private void Update()
    {
        if (muestroPlayer)
        {
            _bot.SetActive(true);
        }
        if (!muestroPlayer)
        {
            _bot.SetActive(false);
        }
    }

    public void BotonComplementoDerecha()
    {
        if (complemento == 0)
        {
            texto_complemento.text = "Gafas Estrella";
            texto_complemento2.text = "Gafas Estrella";
            gafasEstrella.SetActive(true);
            complemento = 1;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 1)
        {
            texto_complemento.text = "Gafas";
            texto_complemento2.text = "Gafas";
            gafasEstrella.SetActive(false);
            gafasRedondas.SetActive(true);
            complemento = 2;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 2)
        {
            texto_complemento.text = "Collar Flor";
            texto_complemento2.text = "Collar Flor";
            gafasRedondas.SetActive(false);
            collarFlor.SetActive(true);
            complemento = 3;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 3)
        {
            texto_complemento.text = "Collar Perlas";
            texto_complemento2.text = "Collar Perlas";
            collarFlor.SetActive(false);
            collarPerlas.SetActive(true);
            complemento = 4;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 4)
        {
            texto_complemento.text = "Gorra";
            texto_complemento2.text = "Gorra";
            collarPerlas.SetActive(false);
            gorra.SetActive(true);
            complemento = 5;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 5)
        {
            texto_complemento.text = "Corona Azul";
            texto_complemento2.text = "Corona Azul";
            gorra.SetActive(false);
            coronaAzul.SetActive(true);
            complemento = 6;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 6)
        {
            texto_complemento.text = "Corona Morada";
            texto_complemento2.text = "Corona Morada";
            coronaAzul.SetActive(false);
            coronaMorada.SetActive(true);
            complemento = 7;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 7)
        {
            texto_complemento.text = "Corona Verde";
            texto_complemento2.text = "Corona Verde";
            coronaMorada.SetActive(false);
            coronaVerde.SetActive(true);
            complemento = 8;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 8)
        {
            texto_complemento.text = "Corona Roja";
            texto_complemento2.text = "Corona Roja";
            coronaVerde.SetActive(false);
            coronaRoja.SetActive(true);
            complemento = 9;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 9)
        {
            texto_complemento.text = "Corona Amarilla";
            texto_complemento2.text = "Corona Amarilla";
            coronaRoja.SetActive(false);
            coronaAmarilla.SetActive(true);
            complemento = 10;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 10)
        {
            texto_complemento.text = "Sombrero Azul";
            texto_complemento2.text = "Sombrero Azul";
            coronaAmarilla.SetActive(false);
            sombreroAzul.SetActive(true);
            complemento = 11;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 11)
        {
            texto_complemento.text = "Sombrero Rojo";
            texto_complemento2.text = "Sombrero Rojo";
            sombreroAzul.SetActive(false);
            sombreroRojo.SetActive(true);
            complemento = 12;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 12)
        {
            texto_complemento.text = "Sombrero Verde";
            texto_complemento2.text = "Sombrero Verde";
            sombreroRojo.SetActive(false);
            sombreroVerde.SetActive(true);
            complemento = 13;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 13)
        {
            texto_complemento.text = "Sombrero Amarillo";
            texto_complemento2.text = "Sombrero Amarillo";
            sombreroVerde.SetActive(false);
            sombreroAmarillo.SetActive(true);
            complemento = 14;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 14)
        {
            texto_complemento.text = "Sombrero Morado";
            texto_complemento2.text = "Sombrero Morado";
            sombreroAmarillo.SetActive(false);
            sombreroMorado.SetActive(true);
            complemento = 15;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 15)
        {
            texto_complemento.text = "Sin complemento";
            texto_complemento2.text = "Sin complemento";
            sombreroMorado.SetActive(false);
            complemento = 0;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
    }

    public void BotonComplementoIzquierda()
    {
        if (complemento == 0)
        {
            texto_complemento.text = "Sombrero Morado";
            texto_complemento2.text = "Sombrero Morado";
            sombreroMorado.SetActive(true);
            complemento = 15;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 1)
        {
            texto_complemento.text = "Sin complemento";
            texto_complemento2.text = "Sin complemento";
            gafasEstrella.SetActive(false);
            complemento = 0;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 2)
        {
            texto_complemento.text = "Gafas Estrella";
            texto_complemento2.text = "Gafas Estrella";
            gafasRedondas.SetActive(false);
            gafasEstrella.SetActive(true);
            complemento = 1;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 3)
        {
            texto_complemento.text = "Gafas";
            texto_complemento2.text = "Gafas";
            collarFlor.SetActive(false);
            gafasRedondas.SetActive(true);
            complemento = 2;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 4)
        {
            texto_complemento.text = "Collar Flor";
            texto_complemento2.text = "Collar Flor";
            collarPerlas.SetActive(false);
            collarFlor.SetActive(true);
            complemento = 3;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 5)
        {
            texto_complemento.text = "Collar Perlas";
            texto_complemento2.text = "Collar Perlas";
            gorra.SetActive(false);
            collarPerlas.SetActive(true);
            complemento = 4;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 6)
        {
            texto_complemento.text = "Gorra";
            texto_complemento2.text = "Gorra";
            coronaAzul.SetActive(false);
            gorra.SetActive(true);
            complemento = 5;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 7)
        {
            texto_complemento.text = "Corona Azul";
            texto_complemento2.text = "Corona Azul";
            coronaMorada.SetActive(false);
            coronaAzul.SetActive(true);
            complemento = 6;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 8)
        {
            texto_complemento.text = "Corona Morada";
            texto_complemento2.text = "Corona Morada";
            coronaVerde.SetActive(false);
            coronaMorada.SetActive(true);
            complemento = 7;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 9)
        {
            texto_complemento.text = "Corona Verde";
            texto_complemento2.text = "Corona Verde";
            coronaRoja.SetActive(false);
            coronaVerde.SetActive(true);
            complemento = 8;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 10)
        {
            texto_complemento.text = "Corona Roja";
            texto_complemento2.text = "Corona Roja";
            coronaAmarilla.SetActive(false);
            coronaRoja.SetActive(true);
            complemento = 9;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 11)
        {
            texto_complemento.text = "Corona Amarilla";
            texto_complemento2.text = "Corona Amarilla";
            sombreroAzul.SetActive(false);
            coronaAmarilla.SetActive(true);
            complemento = 10;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 12)
        {
            texto_complemento.text = "Sombrero Azul";
            texto_complemento2.text = "Sombrero Azul";
            sombreroRojo.SetActive(false);
            sombreroAzul.SetActive(true);
            complemento = 11;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 13)
        {
            texto_complemento.text = "Sombrero Rojo";
            texto_complemento2.text = "Sombrero Rojo";
            sombreroVerde.SetActive(false);
            sombreroRojo.SetActive(true);
            complemento = 12;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 14)
        {
            texto_complemento.text = "Sombrero Verde";
            texto_complemento2.text = "Sombrero Verde";
            sombreroAmarillo.SetActive(false);
            sombreroVerde.SetActive(true);
            complemento = 13;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
        else if (complemento == 15)
        {
            texto_complemento.text = "Sombrero Amarillo";
            texto_complemento2.text = "Sombrero Amarillo";
            sombreroMorado.SetActive(false);
            sombreroAmarillo.SetActive(true);
            complemento = 14;
            PlayerPrefs.SetInt("Complemento", complemento);
        }
    }

    public void cambioColorDerecha()
    {
        if (color == 0)
        {
            texto_color.text = "Color Verde";
            texto_color2.text = "Color Verde";
            color = 1;
            PlayerPrefs.SetInt("Color", color);
            colorO[0].SetActive(false);
            colorO[1].SetActive(false);
            colorO[2].SetActive(false);
            colorO[3].SetActive(false);
            colorO[4].SetActive(false);

            colorV[0].SetActive(true);
            colorV[1].SetActive(true);
            colorV[2].SetActive(true);
            colorV[3].SetActive(true);
            colorV[4].SetActive(true);
        }
        else if (color == 1)
        {
            texto_color.text = "Color Rojo";
            texto_color2.text = "Color Rojo";
            color = 2;
            PlayerPrefs.SetInt("Color", color);
            colorV[0].SetActive(false);
            colorV[1].SetActive(false);
            colorV[2].SetActive(false);
            colorV[3].SetActive(false);
            colorV[4].SetActive(false);

            colorR[0].SetActive(true);
            colorR[1].SetActive(true);
            colorR[2].SetActive(true);
            colorR[3].SetActive(true);
            colorR[4].SetActive(true);
        }
        else if (color == 2)
        {
            texto_color.text = "Color Amarillo";
            texto_color2.text = "Color Amarillo";
            color = 3;
            PlayerPrefs.SetInt("Color", color);
            colorR[0].SetActive(false);
            colorR[1].SetActive(false);
            colorR[2].SetActive(false);
            colorR[3].SetActive(false);
            colorR[4].SetActive(false);

            colorA[0].SetActive(true);
            colorA[1].SetActive(true);
            colorA[2].SetActive(true);
            colorA[3].SetActive(true);
            colorA[4].SetActive(true);
        }
        else if (color == 3)
        {
            texto_color.text = "Color Morado";
            texto_color2.text = "Color Morado";
            color = 4;
            PlayerPrefs.SetInt("Color", color);
            colorA[0].SetActive(false);
            colorA[1].SetActive(false);
            colorA[2].SetActive(false);
            colorA[3].SetActive(false);
            colorA[4].SetActive(false);

            colorM[0].SetActive(true);
            colorM[1].SetActive(true);
            colorM[2].SetActive(true);
            colorM[3].SetActive(true);
            colorM[4].SetActive(true);
        }
        else if (color == 4)
        {
            texto_color.text = "Color Original";
            texto_color2.text = "Color Original";
            color = 0;
            PlayerPrefs.SetInt("Color", color);
            colorM[0].SetActive(false);
            colorM[1].SetActive(false);
            colorM[2].SetActive(false);
            colorM[3].SetActive(false);
            colorM[4].SetActive(false);

            colorO[0].SetActive(true);
            colorO[1].SetActive(true);
            colorO[2].SetActive(true);
            colorO[3].SetActive(true);
            colorO[4].SetActive(true);
        }
    }

    public void cambioColorIzquierda()
    {
        if (color == 0)
        {
            texto_color.text = "Color Morado";
            texto_color2.text = "Color Morado";
            color = 4;
            PlayerPrefs.SetInt("Color", color);
            colorO[0].SetActive(false);
            colorO[1].SetActive(false);
            colorO[2].SetActive(false);
            colorO[3].SetActive(false);
            colorO[4].SetActive(false);

            colorM[0].SetActive(true);
            colorM[1].SetActive(true);
            colorM[2].SetActive(true);
            colorM[3].SetActive(true);
            colorM[4].SetActive(true);
        }
        else if (color == 1)
        {
            texto_color.text = "Color Original";
            texto_color2.text = "Color Original";
            color = 0;
            PlayerPrefs.SetInt("Color", color);
            colorV[0].SetActive(false);
            colorV[1].SetActive(false);
            colorV[2].SetActive(false);
            colorV[3].SetActive(false);
            colorV[4].SetActive(false);

            colorO[0].SetActive(true);
            colorO[1].SetActive(true);
            colorO[2].SetActive(true);
            colorO[3].SetActive(true);
            colorO[4].SetActive(true);
        }
        else if (color == 2)
        {
            texto_color.text = "Color Verde";
            texto_color2.text = "Color Verde";
            color = 1;
            PlayerPrefs.SetInt("Color", color);
            colorR[0].SetActive(false);
            colorR[1].SetActive(false);
            colorR[2].SetActive(false);
            colorR[3].SetActive(false);
            colorR[4].SetActive(false);

            colorV[0].SetActive(true);
            colorV[1].SetActive(true);
            colorV[2].SetActive(true);
            colorV[3].SetActive(true);
            colorV[4].SetActive(true);
        }
        else if (color == 3)
        {
            texto_color.text = "Color Rojo";
            texto_color2.text = "Color Rojo";
            color = 2;
            PlayerPrefs.SetInt("Color", color);
            colorA[0].SetActive(false);
            colorA[1].SetActive(false);
            colorA[2].SetActive(false);
            colorA[3].SetActive(false);
            colorA[4].SetActive(false);

            colorR[0].SetActive(true);
            colorR[1].SetActive(true);
            colorR[2].SetActive(true);
            colorR[3].SetActive(true);
            colorR[4].SetActive(true);
        }
        else if (color == 4)
        {
            texto_color.text = "Color Amarillo";
            texto_color2.text = "Color Amarillo";
            color = 3;
            PlayerPrefs.SetInt("Color", color);
            colorM[0].SetActive(false);
            colorM[1].SetActive(false);
            colorM[2].SetActive(false);
            colorM[3].SetActive(false);
            colorM[4].SetActive(false);

            colorA[0].SetActive(true);
            colorA[1].SetActive(true);
            colorA[2].SetActive(true);
            colorA[3].SetActive(true);
            colorA[4].SetActive(true);
        }
    }

    public void confirmar()
    {
        PlayerPrefs.SetInt("Complemento", complemento);
        PlayerPrefs.SetInt("Color", color);
        muestroPlayer = false;
        vineFija3.SetActive(true);
    }

    public void cancelar()
    {
        PlayerPrefs.SetInt("Complemento", complementoInicial);
        PlayerPrefs.SetInt("Color", colorInicial);
        sigVineta1.SetActive(false);
        sigVineta2.SetActive(false);
        vineFija3.SetActive(false);
        vineFija1.SetActive(true);
        muestroPlayer = true;
        _personalizacion = false;
        _bot.transform.position = P1.position;
    }

    public void cancelar2()
    {
        PlayerPrefs.SetInt("Complemento", complementoInicial);
        PlayerPrefs.SetInt("Color", colorInicial);
        listaVinetas[0].SetActive(false);
        listaVinetas[1].SetActive(false);
        listaVinetas[2].SetActive(false);
        listaVinetas[3].SetActive(false);
        listaVinetas[4].SetActive(false);
        listaVinetas[5].SetActive(false);
        listaVinetas[6].SetActive(false);
        listaVinetas[7].SetActive(false);
        listaVinetas[8].SetActive(false);
        listaVinetas[9].SetActive(false);
        listaVinetas[10].SetActive(false);
        vineFija1.SetActive(true);
        _bot.transform.position = P1.position;
        _personalizacion = false;
    }

    public void continuar1()
    {
        vineFija1.SetActive(false);
        vineFija2.SetActive(true);
        _bot.transform.position = P2.position;
    }

    public void continuar2()
    {
        vineFija2.SetActive(false);
        vineFija1.SetActive(true);
        _bot.transform.position = P1.position;
    }

    public void continuar3()
    {
        vineFija2.SetActive(false);
        vineFija3.SetActive(true);
        muestroPlayer = false;
        PlayerPrefs.SetInt("Complemento", complemento);
        PlayerPrefs.SetInt("Color", color);
    }

    public void ponerNombre()
    {
        textoNombre.text = inputText.text;
        longString = inputText.text;
        checkLenght(longString);
        textoNombre.text = checkLenght(longString);
    }

    private string checkLenght(string x)
    {
        string fixString = "";
        fixString = x.Substring(0, maximoCaracteres);
        return fixString;
    }

    public void desactivarCanvas()
    {
        if (!_personalizacion)
        {
            sigVineta1.GetComponent<agrandar_comic>().hacerCasoClick = true;
            sigVineta2.SetActive(true);
            StartCoroutine(sigVineta1.GetComponent<agrandar_comic>().DisminuirAlpha(sigVineta1, 1));
            //sigVineta2.GetComponent<agrandar_comic>()._personalizacion.SetActive(true);
            perso1.SetActive(false);
            _personalizacion = true;
            muestroPlayer = false;
            sigVineta1.GetComponent<agrandar_comic>().hacerCasoClick = true;
        }
        else if (_personalizacion)
        {
            sigVineta2.GetComponent<agrandar_comic>().hacerCasoClick = true;
            StartCoroutine(sigVineta2.GetComponent<agrandar_comic>().DisminuirAlpha(sigVineta2, 1));
            perso2.SetActive(false);
            sigVineta2.GetComponent<agrandar_comic>().hacerCasoClick = true;
        }
    }

    public IEnumerator activarBot()
    {
        yield return new WaitForSeconds(2);
        _bot.SetActive(true);
    }
}