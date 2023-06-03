using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class agrandar_comic : MonoBehaviour
{
    public GameObject objetoEscalar, siguienteImagen, Transicion, vinetafinal, _personalizacion, _persoScript, _botbase, _bot, vineta10, vinAntGO;
    private Vector3 escalaActual, escalaMaxima;
    public float x, y, z;
    public bool esgrande, yaEstaGrande, vinAnt, usarMontaje, vinNivel2;
    public bool ultimaImagen, activarPuzzle, hacerCasoClick, dobleGrande, meDesvanezco, muestroPersonalizacion, transicionTerminada, cambioPos, 
        _sonido, mostrarSprite;
    public float tamanovineta, tiempoCorrutina, tiempoAlphabaja;
    public int contador = 0;
    public AudioSource sonidoEmpezar, sonidoAcabar, _sonidoCambioEscena;
    [SerializeField] private float fadeDuration, initialVolume, targetVolume, currentFadeTime;
    public static int conteoPiezas;
    public personalizacionBotDragDrop perDragDrop;

    private void Start()
    {
        fadeDuration = 2.0f;
        initialVolume = sonidoAcabar.volume;
        transicionTerminada = false;
        esgrande = false;
        yaEstaGrande = false;
        _bot.SetActive(false);
        _botbase.SetActive(false);
        if (mostrarSprite)
        {
            objetoEscalar.GetComponent<SpriteRenderer>().enabled = false;
        }
        escalaActual = transform.localScale;

        currentFadeTime = 0f;
    }

    private void Update()
    {
        if (esgrande == true && !yaEstaGrande && !ultimaImagen)
        {

            x += 5f * Time.deltaTime;
            y += 5f * Time.deltaTime;
            z += 5f * Time.deltaTime;
            transform.localScale = new Vector3(x, y, z);
        }

        if (x >= tamanovineta)
        {
            if (_sonido)
            {
                //sonidoEmpezar.Play();
                sonidoEmpezar.enabled = true;
                //sonidoAcabar.Stop();

                if (currentFadeTime < fadeDuration)
                {
                    currentFadeTime += Time.deltaTime;
                    float t = currentFadeTime / fadeDuration;
                    float volume = Mathf.Lerp(initialVolume, 0f, t);
                    sonidoAcabar.volume = volume;
                }

                StartCoroutine(apagarSonido());

                //_sonido = false;
            }

            yaEstaGrande = true;

            if (muestroPersonalizacion)
            {
                if (usarMontaje)
                {
                    _bot.SetActive(true);
                    _botbase.SetActive(true);
                }

                if (cambioPos)
                {
                    StartCoroutine(encenderBot());
                    _persoScript.GetComponent<Personalizacion_Personaje>()._bot.SetActive(true);
                    _persoScript.GetComponent<Personalizacion_Personaje>()._bot.transform.position = _persoScript.GetComponent<Personalizacion_Personaje>().P2.position;
                }

                if (!usarMontaje)
                {
                    _persoScript.GetComponent<Personalizacion_Personaje>().muestroPlayer = true;
                    _personalizacion.SetActive(true);
                }

                muestroPersonalizacion = false;
            }

            if (conteoPiezas == 4 && usarMontaje)
            {
                bool part_act = true;
                if (part_act)
                    manager.particulasScale(this.transform.position,new Vector3(2,2,2));
                part_act = false;
                _personalizacion.SetActive(true);
                _bot.SetActive(false);
                _botbase.SetActive(false);
                _persoScript.GetComponent<Personalizacion_Personaje>().muestroPlayer = true;
                enabled = false;
            }
        }

        if (yaEstaGrande && hacerCasoClick)
        {
            /*if (_sonido)
            {
                if (currentFadeTime < fadeDuration)
                {
                    currentFadeTime += Time.deltaTime;
                    float t = currentFadeTime / fadeDuration;
                    float volume = Mathf.Lerp(initialVolume, 0f, t);
                    sonidoAcabar.volume = volume;
                }

                StartCoroutine(apagarSonido());
            }*/

            if (dobleGrande && contador >= 2 && x <= tamanovineta)
            {
                x += 5f * Time.deltaTime;
                y += 5f * Time.deltaTime;
                z += 5f * Time.deltaTime;
                transform.localScale = new Vector3(x, y, z);
            }

            if (dobleGrande && contador >= 2 && x >= tamanovineta)
            {
                ultimaImagen = true;
            }

            if (ultimaImagen && !vinNivel2)
            {
                Transicion.SetActive(true);
                _sonidoCambioEscena.Play();
            }

            siguienteImagen.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            contador += 1;
            esgrande = true;
            objetoEscalar.GetComponent<SpriteRenderer>().enabled = true;
            if (vinetafinal.GetComponent<agrandar_comic>().yaEstaGrande && !ultimaImagen && !dobleGrande && meDesvanezco && hacerCasoClick)
            {
                StartCoroutine(DisminuirAlpha(objetoEscalar, tiempoAlphabaja));
            }

            if (ultimaImagen && !vinNivel2)
            {
                siguienteImagen.SetActive(true);
                x = 3.25f;
                y = 3.25f;
                z = 3.25f;
            }
        }

        if (contador >= 2 && dobleGrande)
        {
            tamanovineta = 12;
        }

        if (contador >= 2 && ultimaImagen && x <= tamanovineta)
        {
            Transicion.SetActive(true);
            x += 5f * Time.deltaTime;
            y += 5f * Time.deltaTime;
            z += 5f * Time.deltaTime;
            transform.localScale = new Vector3(x, y, z);
        }

        if (vinNivel2 && ultimaImagen && esgrande && x < tamanovineta)
        {
            x += 5f * Time.deltaTime;
            y += 5f * Time.deltaTime;
            z += 5f * Time.deltaTime;
            transform.localScale = new Vector3(x, y, z);
        }

        if (vinNivel2 && ultimaImagen && yaEstaGrande && Input.GetMouseButtonDown(0))
        {
            Transicion.SetActive(true);
            _sonidoCambioEscena.Play();
        }
    }

    public IEnumerator DisminuirAlpha(GameObject objeto, float tiempo)
    {
        hacerCasoClick = false;
        SpriteRenderer sr = objeto.GetComponent<SpriteRenderer>();
        Color colorActual = sr.color;

        float tiempoInicio = Time.time;
        float alphaInicio = colorActual.a;

        while (Time.time < tiempoInicio + 0.5f)
        {
            float factor = (Time.time - tiempoInicio) / 0.5f;
            colorActual.a = Mathf.Lerp(alphaInicio, 0f, factor);
            sr.color = colorActual;
            yield return null;
        }

        colorActual.a = 0f;
        sr.color = colorActual;
    }

    public IEnumerator apagarSonido()
    {
        yield return new WaitForSeconds(2);
        sonidoAcabar.Stop();
    }

    public IEnumerator encenderBot()
    {
        yield return new WaitForSeconds(tiempoAlphabaja);
        //_bot.SetActive(true);
        //_botbase.SetActive(true);
    }
}