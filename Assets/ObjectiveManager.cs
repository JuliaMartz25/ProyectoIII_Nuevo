using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{

    public TextMeshProUGUI objetivoPantalla;
    public TextMeshProUGUI objetivoMenu;
    public TextMeshProUGUI ocultarObjetivosText;

    public Image biomaClaro, biomaLago, biomaMont, biomaPlanta, iconoMinibot;

    public string[] listaObjetivos;

    public Color[] colorMinimapa;

    public GameObject checkObjetivos;
    public GameObject fondoObjetivos;
    public GameObject fondoObjetivoActual;
    //public GameObject minimapaObjeto;
    public Image minimapaImagen;
    public GameObject exclamacionMapa;
    public GameObject nieblaClaro;
    public GameObject montInicial, montFinal;
    public Image[] objsSclFadeNvl1;
    private Image holaa;
    private int numObjSclFade;
    public GameObject FlechaIndicadora, FlechaIndicadoraObjetivos, FlechaSalirMapa;
    public float margenBajarFondoObjetivos;
    public float margenSubirFondoObjetivos;
    public float segundosMostrarObjetivo;
    private float miPosicionX;
    private float miPosicionY;
    private static int numeroObjetivo;
    public float velTransicion;
    private bool estadoObjetivo, menuObjetivos, booleansObjetivos;
    public bool yaIconoMinibot;
    public int numeroEvento;
    public float alphaFadeDuration, colorFadeDuration;
    private float alphaStartTime, colorStartTime, alphaObjNvl1StartTime, scaleStartTime;
    private bool aFadeInMapa, aFadeOutMapa, cFadeLago, cFadeClaro, cFadeMont, aFadeInObjNvl1, aFadeOutObjNvl1, sclFadeNvl1, shkEfctMapa, cFadeObjs;
    public float scaleDuration;

    private bool cambioObjetivo, subeFondoObj, vistaObjetivos, FlechaInicioMapa;
    private int numColFadeStart, numColFadeEnd;
    private float segundosEspera;
    private Vector3 posicionMapa, escalaMapa;
    private Vector3 posicionMapaMenu, escalaMapaMenu;
    private Vector3 fuegoStartScale, sombraStartScale, sombraFinalStartScale;

    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.5f;
    private float shakeTimer = 0f;

    private Renderer objetivosRend;
    private Color objetivosAlpha;
    private Color noAlphaColor;
    private Color siAlphaColor;
    private Color segAlphaColor, terAlphaColor, cuarAlphaColor;
    public GameObject FlechaIndicadoraObjetivosPestana;
    public Mov_Flechas_Final movFlechas;

    [SerializeField] private AudioSource _nuevoObjetivo, _objetivoCompletado;

    // Start is called before the first frame update
    void Start()
    {
        yaIconoMinibot = false;
        FlechaInicioMapa = true;
        noAlphaColor = new Color(1f, 1f, 1f, 0f);
        siAlphaColor = new Color(1f, 1f, 1f, 1f);
        segAlphaColor = new Color(1f, 1f, 1f, 0.9f);
        terAlphaColor = new Color(1f, 1f, 1f, 0.75f);
        cuarAlphaColor = new Color(1f, 1f, 1f, 0.3f);

        cambioObjetivo = false;
        subeFondoObj = false;
        menuObjetivos = false;
        vistaObjetivos = true;
        aFadeInMapa = false;
        aFadeOutMapa = false;
        cFadeLago = false;
        aFadeInObjNvl1 = false;
        sclFadeNvl1 = false;
        shkEfctMapa = false;
        cFadeObjs = false;
        booleansObjetivos = false;

        checkObjetivos.SetActive(false);
        fondoObjetivoActual.SetActive(false);
        exclamacionMapa.SetActive(false);
        nieblaClaro.SetActive(false);
        montInicial.SetActive(true);
        montFinal.SetActive(false);
        numeroObjetivo = 0;
        numeroEvento = 0;
        estadoObjetivo = false;
        miPosicionX = fondoObjetivos.transform.position.x;
        miPosicionY = fondoObjetivos.transform.position.y;
        fondoObjetivos.transform.position = new Vector3(miPosicionX, miPosicionY, 0);

        objetivoPantalla.text = listaObjetivos[numeroObjetivo];
        objetivoMenu.text = listaObjetivos[numeroObjetivo];
        ocultarObjetivosText.text = "Ocultar Objetivos";

        minimapaImagen.material.color = new Color(1f, 1f, 1f, 0f);

        posicionMapa = minimapaImagen.transform.position;
        escalaMapa = minimapaImagen.transform.localScale;
        posicionMapaMenu = new Vector3(654f, 554f, 0f);
        escalaMapaMenu = new Vector3(5.5f, 5.5f, 5.5f);

        fuegoStartScale = objsSclFadeNvl1[0].transform.localScale;
        sombraStartScale = objsSclFadeNvl1[9].transform.localScale;
        sombraFinalStartScale = objsSclFadeNvl1[19].transform.localScale;
        numObjSclFade = 0;

        objsSclFadeNvl1[0].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[1].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[2].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[3].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[4].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[5].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[6].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[7].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[8].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[9].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[10].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[11].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[12].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[13].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[14].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[15].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[16].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[17].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[18].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[19].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[20].material.SetColor("_Color", noAlphaColor);
        objsSclFadeNvl1[21].material.SetColor("_Color", noAlphaColor);
        iconoMinibot.material.SetColor("_Color", noAlphaColor);

    }

    // Update is called once per frame
    void Update()
    {
        if (cambioObjetivo == true)
        {
            ApareceObjetivo();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //MostrarEventos();
            //MenuObjetivos();
            StartCoroutine("AvanceObjetivos");
        }
        print(numeroObjetivo);

        if (Input.GetKeyDown(KeyCode.E))
        {
            numeroEvento += 5;
            AvanceEventos();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            movFlechas.ValorMedidor = 30;
            movFlechas.ComprobColMedidor();
            SceneManager.LoadScene("Nivel1");
        }

        if (aFadeInMapa == false && aFadeOutMapa == false)
        {
            alphaStartTime = Time.time;
        }

        if (cFadeLago == false && cFadeClaro == false && cFadeMont == false && cFadeObjs == false)
        {
            colorStartTime = Time.time;
        }

        if (aFadeInObjNvl1 == false && aFadeOutObjNvl1 == false)
        {
            alphaObjNvl1StartTime = Time.time;
        }

        if (sclFadeNvl1 == false)
        {
            scaleStartTime = Time.time;
        }

        AlphaFaderInMapa();
        ColorFaderLago();
        ColorFaderClaro();
        ColorFaderMont();
        AlphaFaderOutMapa();
        AlphaFaderInObjsNvl1();
        AlphaFaderOutObjsNvl1();
        ScaleFaderInObj1();
        ShakeEffectMapa();
        ColorFaderObjs();

        //print(alphaStartTime);
    }

    /*IEnumerator InfoObjetivos()
    {
        if (fondoObjetivos.transform.position.y > margenBajarFondoObjetivos)
        {
            fondoObjetivos.transform.position = new Vector3(miPosicionX, miPosicionY - 100, 0);
            print("abajo");
        }
        
        yield return new WaitForSeconds(segundosMostrarObjetivo);

        if (fondoObjetivos.transform.position.y < margenSubirFondoObjetivos)
        {
            fondoObjetivos.transform.position = new Vector3(miPosicionX, miPosicionY, 0);
            print("arriba");
        }
    }*/

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Objetivo")
        {
            //cambioObjetivo = true;
            StartCoroutine("AvanceObjetivos");
            print("cuadrado");
        }
    }

    public void ApareceObjetivo()
    {
        _nuevoObjetivo.Play();

        if (fondoObjetivos.transform.position.y > margenBajarFondoObjetivos && subeFondoObj == false)
        {
            fondoObjetivos.transform.Translate(Vector3.down * velTransicion * Time.deltaTime, Space.Self);
            print("aparece abajo");

            StartCoroutine("EsperaObjetivos");
        }

        if (fondoObjetivos.transform.position.y < margenSubirFondoObjetivos && subeFondoObj == true)
        {
            fondoObjetivos.transform.Translate(Vector3.up * velTransicion * Time.deltaTime, Space.Self);
            print("aparece arriba");

            StartCoroutine("EsperaObjetivos");
        }
    }

    IEnumerator EsperaObjetivos()
    {
        yield return new WaitForSeconds(segundosMostrarObjetivo);
        
        if (booleansObjetivos == false)
        {
            if (cambioObjetivo == true)
            {
                subeFondoObj = true;
            }

            if (cambioObjetivo == true && fondoObjetivos.transform.position.y >= margenSubirFondoObjetivos)
            {
                
                booleansObjetivos = true;
                cambioObjetivo = false;
                subeFondoObj = false;
            }
        }

    }

    IEnumerator AvanceObjetivos()
    {
        print("avance objetivos");
        
        if (cambioObjetivo == true)
        {
            yield return new WaitForSeconds(segundosMostrarObjetivo * 2.5f);
        }

        switch (estadoObjetivo)
        {
            case false:
            checkObjetivos.SetActive(false);
            objetivoPantalla.text = listaObjetivos[numeroObjetivo];
            objetivoMenu.text = listaObjetivos[numeroObjetivo];
            estadoObjetivo = true;
            break;

            case true:
            checkObjetivos.SetActive(true);
            objetivoPantalla.text = listaObjetivos[numeroObjetivo];
            objetivoMenu.text = "Sigue explorando el planeta";
            numeroObjetivo += 1;
            estadoObjetivo = false;
            break;
        }

        cambioObjetivo = true;
        booleansObjetivos = false;
    }

    public void MenuObjetivos()
    {
        print("cambio menu eventos");
        switch (menuObjetivos)
        {
            case false:
            if (yaIconoMinibot == true)
            {
                iconoMinibot.material.SetColor("_Color", siAlphaColor);
            }
          /*  Follow.CanMove = false;
            Follow.MovActivado = false;*/
            FlechaIndicadoraObjetivosPestana.SetActive(false);
            fondoObjetivoActual.SetActive(true);
            exclamacionMapa.SetActive(false);
            FlechaSalirMapa.SetActive(true);
            minimapaImagen.transform.position = posicionMapaMenu;
            minimapaImagen.transform.localScale = escalaMapaMenu;
            menuObjetivos = true;
            FlechaIndicadora.SetActive(false);
            if(FlechaInicioMapa == true)
            {
                FlechaIndicadoraObjetivos.SetActive(true);
                FlechaInicioMapa = false;

            }
            break;

            case true:
            iconoMinibot.material.SetColor("_Color", noAlphaColor);
           /* Follow.CanMove = true;
            Follow.MovActivado = true;*/
            fondoObjetivoActual.SetActive(false);
            FlechaSalirMapa.SetActive(false);
            minimapaImagen.transform.position = posicionMapa;
            minimapaImagen.transform.localScale = escalaMapa;
            menuObjetivos = false;
            FlechaIndicadoraObjetivos.SetActive(false);
            break;
        }
    }

    public void OcultarMostrarObjetivos()
    {
        //objetivosRend.material.color = objetivosAlpha;

        switch (vistaObjetivos)
        {
            case true:
            fondoObjetivos.SetActive(false);
            vistaObjetivos = false;
            ocultarObjetivosText.text = "Mostrar Objetivos";
            break;

            case false:
            fondoObjetivos.SetActive(true);
            vistaObjetivos = true;
            ocultarObjetivosText.text = "Ocultar Objetivos";
            break;
        }
    }

    public void AvanceEventos()
    {
        numeroEvento ++;
        _objetivoCompletado.Play();

        switch (numeroEvento)
        {
            case 1:
            aFadeInMapa = true;
            biomaClaro.color = colorMinimapa[0];
            biomaMont.color = colorMinimapa[0];
            biomaLago.color = colorMinimapa[3];
            biomaPlanta.color = colorMinimapa[3];
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 2:
            numColFadeStart = 3;
            numColFadeEnd = 4;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[4];
            segundosEspera = 1.5f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 3:
            numColFadeStart = 4;
            numColFadeEnd = 3;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[3];
            segundosEspera = 1.5f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 4:
            numColFadeStart = 3;
            numColFadeEnd = 2;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[2];
            break;

            case 5:
            numColFadeStart = 2;
            numColFadeEnd = 1;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[1];
            break;

            case 6:
            segundosEspera = 0f;
            StartCoroutine("EsperaExclamacion");
            numColFadeStart = 1;
            numColFadeEnd = 0;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[0];
            segundosEspera = 4f;
            StartCoroutine("EsperaFadeOut");
            break;

            case 7:
            montInicial.SetActive(false);
            montFinal.SetActive(true);
            numObjSclFade = 0;
            nieblaClaro.SetActive(true);
            aFadeInMapa = true;
            aFadeInObjNvl1 = true;
            biomaClaro.color = colorMinimapa[5];
            biomaMont.color = colorMinimapa[7];
            objsSclFadeNvl1[21].color = colorMinimapa[7];
            biomaLago.color = colorMinimapa[7];
            biomaPlanta.color = colorMinimapa[7];
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 8:
            numObjSclFade = 10;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 5;
            numColFadeEnd = 7;
            cFadeClaro = true;
            break;

            case 9:
            objsSclFadeNvl1[2].material.SetColor("_Color", siAlphaColor);
            numObjSclFade = 2;
            sclFadeNvl1 = true;
            numColFadeStart = 7;
            numColFadeEnd = 6;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[6];
            segundosEspera = 1.5f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 10:
            objsSclFadeNvl1[3].material.SetColor("_Color", siAlphaColor);
            numObjSclFade = 3;
            sclFadeNvl1 = true;
            numColFadeStart = 6;
            numColFadeEnd = 5;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[5];
            break;

            case 11:
            numObjSclFade = 3;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 5;
            numColFadeEnd = 6;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[6];
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 12:
            numObjSclFade = 2;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 6;
            numColFadeEnd = 7;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[7];
            break;

            case 13:
            numObjSclFade = 1;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 7;
            numColFadeEnd = 8;
            cFadeLago = true;
            cFadeClaro = true;
            biomaPlanta.color = colorMinimapa[8];
            break;

            case 14:
            numObjSclFade = 0;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 8;
            numColFadeEnd = 9;
            cFadeLago = true;
            cFadeClaro = true;
            biomaPlanta.color = colorMinimapa[9];
            break;

            case 15:
            numObjSclFade = 6;
            aFadeInObjNvl1 = true;
            numColFadeStart = 7;
            numColFadeEnd = 6;
            cFadeMont = true;
            biomaPlanta.color = colorMinimapa[6];
            shakeTimer = shakeDuration;
            shkEfctMapa = true;
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 16:
            numColFadeStart = 9;
            numColFadeEnd = 0;
            cFadeLago = true;
            cFadeClaro = true;
            biomaPlanta.color = colorMinimapa[7];
            break;

            case 17:
            objsSclFadeNvl1[9].material.SetColor("_Color", siAlphaColor);
            numObjSclFade = 9;
            sclFadeNvl1 = true;
            numColFadeStart = 6;
            numColFadeEnd = 5;
            cFadeMont = true;
            biomaPlanta.color = colorMinimapa[5];
            shakeTimer = shakeDuration;
            shkEfctMapa = true;
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 18:
            segundosEspera = 0f;
            StartCoroutine("EsperaExclamacion");
            numObjSclFade = 9;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 5;
            numColFadeEnd = 0;
            cFadeMont = true;
            biomaPlanta.color = colorMinimapa[0];
            segundosEspera = 4f;
            StartCoroutine("EsperaFadeOut");
            break;

            case 19:
            numObjSclFade = 11;
            aFadeInMapa = true;
            aFadeInObjNvl1 = true;
            biomaClaro.color = colorMinimapa[10];
            biomaMont.color = colorMinimapa[12];
            objsSclFadeNvl1[21].color = colorMinimapa[12];
            biomaLago.color = colorMinimapa[10];
            biomaPlanta.color = colorMinimapa[10];
            objsSclFadeNvl1[15].color = colorMinimapa[10];
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 20:
            objsSclFadeNvl1[15].material.SetColor("_Color", segAlphaColor);
            numObjSclFade = 11;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 10;
            numColFadeEnd = 11;
            cFadeLago = true;
            cFadeObjs = true;
            break;

            case 21:
            objsSclFadeNvl1[15].material.SetColor("_Color", terAlphaColor);
            numObjSclFade = 12;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 11;
            numColFadeEnd = 12;
            cFadeLago = true;
            cFadeObjs = true;
            biomaPlanta.color = colorMinimapa[11];
            break;

            case 22:
            objsSclFadeNvl1[15].material.SetColor("_Color", cuarAlphaColor);
            numColFadeStart = 10;
            numColFadeEnd = 11;
            cFadeClaro = true;
            cFadeObjs = true;
            break;

            case 23:
            numObjSclFade = 13;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 11;
            numColFadeEnd = 12;
            cFadeClaro = true;
            biomaPlanta.color = colorMinimapa[12];
            shakeTimer = shakeDuration;
            shkEfctMapa = true;
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 24:
            segundosEspera = 0f;
            StartCoroutine("EsperaExclamacion");
            numObjSclFade = 14;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 13;
            numColFadeEnd = 0;
            cFadeMont = true;
            cFadeClaro = true;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[0];
            segundosEspera = 4f;
            StartCoroutine("EsperaFadeOut");
            break;

            case 25:
            numObjSclFade = 16;
            aFadeInMapa = true;
            aFadeInObjNvl1 = true;
            biomaClaro.color = colorMinimapa[15];
            biomaMont.color = colorMinimapa[14];
            objsSclFadeNvl1[21].color = colorMinimapa[14];
            biomaLago.color = colorMinimapa[14];
            biomaPlanta.color = colorMinimapa[14];
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 26:
            numObjSclFade = 19;
            sclFadeNvl1 = true;
            aFadeInObjNvl1 = true;
            objsSclFadeNvl1[20].color = colorMinimapa[14];
            shakeTimer = shakeDuration;
            shkEfctMapa = true;
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 27:
            objsSclFadeNvl1[20].material.SetColor("_Color", segAlphaColor);
            numObjSclFade = 18;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 14;
            numColFadeEnd = 15;
            cFadeMont = true;
            cFadeObjs = true;
            break;

            case 28:
            numObjSclFade = 17;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 14;
            numColFadeEnd = 15;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[15];
            shakeTimer = shakeDuration;
            shkEfctMapa = true;
            segundosEspera = 2f;
            StartCoroutine("EsperaExclamacion");
            break;

            case 29:
            segundosEspera = 0f;
            StartCoroutine("EsperaExclamacion");
            numObjSclFade = 19;
            aFadeOutObjNvl1 = true;
            numColFadeStart = 15;
            numColFadeEnd = 0;
            cFadeMont = true;
            cFadeClaro = true;
            cFadeLago = true;
            biomaPlanta.color = colorMinimapa[0];
            segundosEspera = 4f;
            StartCoroutine("EsperaFadeOut");
            break;

        }
    }

    public void MostrarEventos()
    {
        print("menu eventitos");

        if (menuObjetivos == true)
        {
            switch (numeroEvento)
            {

                case 2:
                numColFadeStart = 3;
                numColFadeEnd = 4;
                cFadeLago = true;
                break;

                case 3:
                numColFadeStart = 4;
                numColFadeEnd = 3;
                cFadeLago = true;
                break;

                case 4:
                numColFadeStart = 3;
                numColFadeEnd = 2;
                cFadeLago = true;
                break;

                case 5:
                numColFadeStart = 2;
                numColFadeEnd = 1;
                cFadeLago = true;
                break;

                case 8:
                objsSclFadeNvl1[10].material.SetColor("_Color", siAlphaColor);
                numObjSclFade = 10;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 5;
                numColFadeEnd = 7;
                cFadeClaro = true;
                break;

                case 9:
                numObjSclFade = 2;
                sclFadeNvl1 = true;
                numColFadeStart = 7;
                numColFadeEnd = 6;
                cFadeLago = true;
                break;

                case 10:
                numObjSclFade = 3;
                sclFadeNvl1 = true;
                numColFadeStart = 6;
                numColFadeEnd = 5;
                cFadeLago = true;
                break;

                case 11:
                numObjSclFade = 3;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 5;
                numColFadeEnd = 6;
                cFadeLago = true;
                break;

                case 12:
                numObjSclFade = 2;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 6;
                numColFadeEnd = 7;
                cFadeLago = true;
                break;

                case 13:
                numObjSclFade = 1;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 7;
                numColFadeEnd = 8;
                cFadeLago = true;
                cFadeClaro = true;
                break;

                case 14:
                numObjSclFade = 0;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 8;
                numColFadeEnd = 9;
                cFadeLago = true;
                cFadeClaro = true;
                break;

                case 15:
                numObjSclFade = 6;
                aFadeInObjNvl1 = true;
                numColFadeStart = 7;
                numColFadeEnd = 6;
                cFadeMont = true;
                shakeTimer = shakeDuration;
                shkEfctMapa = true;
                break;

                case 16:
                numColFadeStart = 9;
                numColFadeEnd = 0;
                cFadeLago = true;
                cFadeClaro = true;
                break;

                case 17:
                numObjSclFade = 9;
                sclFadeNvl1 = true;
                numColFadeStart = 6;
                numColFadeEnd = 5;
                cFadeMont = true;
                shakeTimer = shakeDuration;
                shkEfctMapa = true;
                break;

                case 20:
                objsSclFadeNvl1[15].material.SetColor("_Color", segAlphaColor);
                numObjSclFade = 11;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 10;
                numColFadeEnd = 11;
                cFadeLago = true;
                cFadeObjs = true;
                break;

                case 21:
                objsSclFadeNvl1[15].material.SetColor("_Color", terAlphaColor);
                numObjSclFade = 12;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 11;
                numColFadeEnd = 12;
                cFadeLago = true;
                cFadeObjs = true;
                break;

                case 22:
                objsSclFadeNvl1[15].material.SetColor("_Color", cuarAlphaColor);
                numColFadeStart = 10;
                numColFadeEnd = 11;
                cFadeClaro = true;
                cFadeObjs = true;
                break;

                case 23:
                numObjSclFade = 13;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 11;
                numColFadeEnd = 12;
                cFadeClaro = true;
                shakeTimer = shakeDuration;
                shkEfctMapa = true;
                break;

                case 26:
                numObjSclFade = 19;
                sclFadeNvl1 = true;
                aFadeInObjNvl1 = true;
                objsSclFadeNvl1[20].color = colorMinimapa[14];
                shakeTimer = shakeDuration;
                shkEfctMapa = true;
                break;

                case 27:
                objsSclFadeNvl1[20].material.SetColor("_Color", segAlphaColor);
                numObjSclFade = 18;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 14;
                numColFadeEnd = 15;
                cFadeMont = true;
                cFadeObjs = true;
                break;

                case 28:
                numObjSclFade = 17;
                aFadeOutObjNvl1 = true;
                numColFadeStart = 14;
                numColFadeEnd = 15;
                cFadeLago = true;
                shakeTimer = shakeDuration;
                shkEfctMapa = true;
                break;
            }
        }
    }

    private void AlphaFaderInMapa()
    {
        if (aFadeInMapa == true)
        {
            float t = (Time.time - alphaStartTime) / alphaFadeDuration;
            float alpha = Mathf.Lerp(0.0f, 1.0f, t);
            minimapaImagen.material.color = new Color(minimapaImagen.color.r, minimapaImagen.color.g, minimapaImagen.color.b, alpha);

            if (t >= 1.0f)
            {
                aFadeInMapa = false;
            }
        }
    }

    private void AlphaFaderOutMapa()
    {
        if (aFadeOutMapa == true)
        {
            float t = (Time.time - alphaStartTime) / alphaFadeDuration;
            float alpha = Mathf.Lerp(1.0f, 0.0f, t);
            minimapaImagen.material.color = new Color(minimapaImagen.color.r, minimapaImagen.color.g, minimapaImagen.color.b, alpha);

            if (t >= 1.0f)
            {
                aFadeOutMapa = false;
                
                if (menuObjetivos == true)
                {
                    print("no pinta menu");
                    MenuObjetivos();
                }
            }
        }
    }

    private void ColorFaderLago()
    {
        if (cFadeLago == true)
        {
            float t = (Time.time - colorStartTime) / colorFadeDuration;
            biomaLago.color = Color.Lerp(colorMinimapa[numColFadeStart], colorMinimapa[numColFadeEnd], t);

            if (t >= 1.0f)
            {
                cFadeLago = false;
            }
        }
    }

    private void ColorFaderClaro()
    {
        if (cFadeClaro == true)
        {
            float t = (Time.time - colorStartTime) / colorFadeDuration;
            biomaClaro.color = Color.Lerp(colorMinimapa[numColFadeStart], colorMinimapa[numColFadeEnd], t);

            if (t >= 1.0f)
            {
                cFadeClaro = false;
            }
        }
    }

    private void ColorFaderMont()
    {
        if (cFadeMont == true)
        {
            float t = (Time.time - colorStartTime) / colorFadeDuration;
            biomaMont.color = Color.Lerp(colorMinimapa[numColFadeStart], colorMinimapa[numColFadeEnd], t);
            objsSclFadeNvl1[21].color = Color.Lerp(colorMinimapa[numColFadeStart], colorMinimapa[numColFadeEnd], t);

            if (t >= 1.0f)
            {
                cFadeMont = false;
            }
        }
    }

    private void ColorFaderObjs()
    {
        if (cFadeObjs == true)
        {
            float t = (Time.time - colorStartTime) / colorFadeDuration;

            if (numeroEvento == 20)
            {
                objsSclFadeNvl1[15].color = Color.Lerp(colorMinimapa[10], colorMinimapa[11], t);
            }
            if (numeroEvento == 21)
            {
                objsSclFadeNvl1[15].color = Color.Lerp(colorMinimapa[11], colorMinimapa[13], t);
            }
            if (numeroEvento == 22)
            {
                //objsSclFadeNvl1[15].color = Color.Lerp(colorMinimapa[13], colorMinimapa[13], t);
            }
            if (numeroEvento == 27)
            {
                objsSclFadeNvl1[20].color = Color.Lerp(colorMinimapa[14], colorMinimapa[15], t);
            }

            if (t >= 1.0f)
            {
                cFadeObjs = false;
            }
        }
    }

    private void ScaleFaderInObj1()
    {
        Vector3 startScale = fuegoStartScale;

        if (numeroEvento == 17)
        {
            startScale = sombraStartScale;
        }
        if (numeroEvento == 26)
        {
            startScale = sombraFinalStartScale;
        }

        if (sclFadeNvl1 == true)
        {
            float scaleT = (Time.time - scaleStartTime) / scaleDuration;
            float scale = Mathf.Lerp(0.0f, startScale.x, scaleT);
            objsSclFadeNvl1[numObjSclFade].transform.localScale = new Vector3(scale, scale, 1.0f);

            if (scaleT >= 1.0f)
            {
                sclFadeNvl1 = false;
            }
        }
    }

    private void AlphaFaderInObjsNvl1()
    {
        if (aFadeInObjNvl1 == true)
        {
            float t = (Time.time - alphaObjNvl1StartTime) / alphaFadeDuration;
            float alpha = Mathf.Lerp(0.0f, 1.0f, t);
            objsSclFadeNvl1[numObjSclFade].material.color = new Color(objsSclFadeNvl1[numObjSclFade].color.r, objsSclFadeNvl1[numObjSclFade].color.g, objsSclFadeNvl1[numObjSclFade].color.b, alpha);
            
            if (numeroEvento == 7)
            {
                objsSclFadeNvl1[1].material.color = new Color(objsSclFadeNvl1[1].color.r, objsSclFadeNvl1[1].color.g, objsSclFadeNvl1[1].color.b, alpha);
                objsSclFadeNvl1[4].material.color = new Color(objsSclFadeNvl1[4].color.r, objsSclFadeNvl1[4].color.g, objsSclFadeNvl1[4].color.b, alpha);
                objsSclFadeNvl1[5].material.color = new Color(objsSclFadeNvl1[5].color.r, objsSclFadeNvl1[5].color.g, objsSclFadeNvl1[5].color.b, alpha);
                objsSclFadeNvl1[10].material.color = new Color(objsSclFadeNvl1[10].color.r, objsSclFadeNvl1[10].color.g, objsSclFadeNvl1[10].color.b, alpha);
                objsSclFadeNvl1[21].material.color = new Color(objsSclFadeNvl1[10].color.r, objsSclFadeNvl1[10].color.g, objsSclFadeNvl1[10].color.b, alpha);
            }
            if (numeroEvento == 19)
            {
                objsSclFadeNvl1[12].material.color = new Color(objsSclFadeNvl1[12].color.r, objsSclFadeNvl1[12].color.g, objsSclFadeNvl1[12].color.b, alpha);
                objsSclFadeNvl1[13].material.color = new Color(objsSclFadeNvl1[13].color.r, objsSclFadeNvl1[13].color.g, objsSclFadeNvl1[13].color.b, alpha);
                objsSclFadeNvl1[14].material.color = new Color(objsSclFadeNvl1[14].color.r, objsSclFadeNvl1[14].color.g, objsSclFadeNvl1[14].color.b, alpha);
                objsSclFadeNvl1[15].material.color = new Color(objsSclFadeNvl1[15].color.r, objsSclFadeNvl1[15].color.g, objsSclFadeNvl1[15].color.b, alpha); 
            }
            if (numeroEvento == 25)
            {
                objsSclFadeNvl1[17].material.color = new Color(objsSclFadeNvl1[17].color.r, objsSclFadeNvl1[17].color.g, objsSclFadeNvl1[17].color.b, alpha);
                /*objsSclFadeNvl1[18].material.color = new Color(objsSclFadeNvl1[18].color.r, objsSclFadeNvl1[18].color.g, objsSclFadeNvl1[18].color.b, alpha);
                objsSclFadeNvl1[19].material.color = new Color(objsSclFadeNvl1[19].color.r, objsSclFadeNvl1[19].color.g, objsSclFadeNvl1[19].color.b, alpha);
                objsSclFadeNvl1[20].material.color = new Color(objsSclFadeNvl1[20].color.r, objsSclFadeNvl1[20].color.g, objsSclFadeNvl1[20].color.b, alpha);*/
            }
            if (numeroEvento == 26)
            {
                objsSclFadeNvl1[18].material.color = new Color(objsSclFadeNvl1[18].color.r, objsSclFadeNvl1[18].color.g, objsSclFadeNvl1[18].color.b, alpha);
                objsSclFadeNvl1[20].material.color = new Color(objsSclFadeNvl1[20].color.r, objsSclFadeNvl1[20].color.g, objsSclFadeNvl1[20].color.b, alpha);
            }

            if (t >= 1.0f)
            {
                aFadeInObjNvl1 = false;
            }
        }
    }

    private void AlphaFaderOutObjsNvl1()
    {
        if (aFadeOutObjNvl1 == true)
        {
            float t = (Time.time - alphaObjNvl1StartTime) / alphaFadeDuration;
            float alpha = Mathf.Lerp(1.0f, 0.0f, t);
            objsSclFadeNvl1[numObjSclFade].material.color = new Color(objsSclFadeNvl1[numObjSclFade].color.r, objsSclFadeNvl1[numObjSclFade].color.g, objsSclFadeNvl1[numObjSclFade].color.b, alpha);

            if (numeroEvento == 18)
            {
                objsSclFadeNvl1[4].material.color = new Color(objsSclFadeNvl1[4].color.r, objsSclFadeNvl1[4].color.g, objsSclFadeNvl1[4].color.b, alpha);
                objsSclFadeNvl1[5].material.color = new Color(objsSclFadeNvl1[5].color.r, objsSclFadeNvl1[5].color.g, objsSclFadeNvl1[5].color.b, alpha);
                objsSclFadeNvl1[6].material.color = new Color(objsSclFadeNvl1[6].color.r, objsSclFadeNvl1[6].color.g, objsSclFadeNvl1[6].color.b, alpha);
                objsSclFadeNvl1[7].material.color = new Color(objsSclFadeNvl1[7].color.r, objsSclFadeNvl1[7].color.g, objsSclFadeNvl1[7].color.b, alpha);
                objsSclFadeNvl1[8].material.color = new Color(objsSclFadeNvl1[8].color.r, objsSclFadeNvl1[8].color.g, objsSclFadeNvl1[8].color.b, alpha);
            }
            if (numeroEvento == 23)
            {
                objsSclFadeNvl1[15].material.color = new Color(objsSclFadeNvl1[15].color.r, objsSclFadeNvl1[15].color.g, objsSclFadeNvl1[15].color.b, alpha);
            }
            if (numeroEvento == 28)
            {
                objsSclFadeNvl1[20].material.color = new Color(objsSclFadeNvl1[20].color.r, objsSclFadeNvl1[20].color.g, objsSclFadeNvl1[20].color.b, alpha);
            }
            if (numeroEvento == 29)
            {
                objsSclFadeNvl1[16].material.color = new Color(objsSclFadeNvl1[16].color.r, objsSclFadeNvl1[16].color.g, objsSclFadeNvl1[16].color.b, alpha);
            }

            if (t >= 1.0f)
            {
                aFadeOutObjNvl1 = false;
            }
        }
    }

    private void ShakeEffectMapa()
    {
        if (shkEfctMapa == true)
        {
            Vector3 originalPosition;

            switch (menuObjetivos)
            {
                case false:
                originalPosition = posicionMapa;
                break;

                case true:
                originalPosition = posicionMapaMenu;
                break;
            }
            
            if (shakeTimer > 0f)
            {
                minimapaImagen.transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
                shakeTimer -= Time.deltaTime;
            }
            else
            {
                shakeTimer = 0f;
                minimapaImagen.transform.position = originalPosition;
                shkEfctMapa = false;
            }
        }
    }

    IEnumerator EsperaFadeOut()
    {
        yield return new WaitForSeconds(segundosEspera);
        aFadeOutMapa = true;
    }

    IEnumerator EsperaExclamacion()
    {
        yield return new WaitForSeconds(segundosEspera);
        if (menuObjetivos == false)
        {
            exclamacionMapa.SetActive(true);
        }
    }
}
