using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollow : MonoBehaviour
{
    private Camera MainCamera;

    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private Rigidbody2D rb;

    private bool Mocotocado;
    public static bool Comenzar;

    private Animator anim;
    [SerializeField] private GameObject ImageFinal, mocoAmarillo, mocoVerde, mocoRojo, mocoAzul;
    [SerializeField] private CursorType cursor, Default;

    public static int NivelActual;

    private float posAnteriorX;

    [SerializeField] private AudioSource sonidoMocos;

    void Start()
    {
        MainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Comenzar = false;
        Mocotocado = false;
    }

    void Update()
    {
        followMousePositionDelay(maxSpeed);
        if (Mocotocado)
        {
            maxSpeed = 1f;
        }

        if (Comenzar)
        {
            anim.SetBool("Volar", true);
        }
        //flip del cursor
        if (transform.position.x > posAnteriorX)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            Cursor.SetCursor(Default.CursorTexture, Default.CursorHotspot, CursorMode.Auto);
        }
        if (transform.position.x < posAnteriorX)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Cursor.SetCursor(cursor.CursorTexture, cursor.CursorHotspot, CursorMode.Auto);
        }
        posAnteriorX = transform.position.x;
    }
    //seguramente ponerselo al character controller (si se gasta el del tutorial, sino aqui creo qeu esta bien)
    private void followMousePositionDelay(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);   
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {//seguramente haya otra forma de hacerlo sin pasar por tantas tag's
        if(col.collider.CompareTag("MocoVerde"))
        {
            Mocotocado = true;
            mocoVerde.SetActive(true);
            sonidoMocos.Play();
            StartCoroutine("GolpeMoco");
        }

        if (col.collider.CompareTag("MocoAmarillo"))
        {
            Mocotocado = true;
            mocoAmarillo.SetActive(true);
            sonidoMocos.Play();
            StartCoroutine("GolpeMoco");
        }

        if (col.collider.CompareTag("MocoRojo"))
        {
            Mocotocado = true;
            mocoRojo.SetActive(true);
            sonidoMocos.Play();
            StartCoroutine("GolpeMoco");
        }

        if (col.collider.CompareTag("MocoAzul"))
        {
            Mocotocado = true;
            mocoAzul.SetActive(true);   
            sonidoMocos.Play();
            StartCoroutine("GolpeMoco");
        }

        if (col.collider.CompareTag("FinalMocos"))
        {
            anim.applyRootMotion = false;
            switch (NivelActual)
            {
                case 0:
                    Comenzar = false;
                    anim.SetBool("Volar", false);
                    anim.SetBool("Final", true);
                    break;
                case 1:
                    Comenzar = false;
                    anim.SetBool("Volar", false);
                    anim.SetBool("Mocos_Final1", true);
                    break;
                case 2:
                    Comenzar = false;
                    anim.SetBool("Volar", false);
                    anim.SetBool("Moco_final2", true);//preguntar si son animaciones diferentes
                    break;
                    default:
                    break;
            }
           
        }

        if (col.collider.CompareTag("Pelos"))
        {
            sonidoMocos.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("FueraEscena"))
        {
            switch (NivelActual)
            {
                case 0:
                    SceneManager.LoadScene("Mocos");
                    break;
                case 1:
                    SceneManager.LoadScene("MocosNivel1");
                    break;
                case 2:
                    SceneManager.LoadScene("MocosNivel2");
                    break;
                default:
                    break;
            }
        } 
    }

    private IEnumerator GolpeMoco()
    {
        yield return new WaitForSeconds(1f);
        maxSpeed = 7f;
        Mocotocado = false;
        mocoAmarillo.SetActive(false);
        mocoRojo.SetActive(false);
        mocoVerde.SetActive(false);
        mocoAzul.SetActive(false);
    }
//seguramente quitar
    private void ActivarPanel()
    {
        ImageFinal.SetActive(true);
    }
    private void CambioEscena()
    {
        SceneManager.LoadScene("Tutorial");
    }
    private void CambioNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }
    private void CambioNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

}