using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Camera MainCamera;

    [SerializeField] public static float maxSpeed;
    [SerializeField] private GameObject Player; // texto;
    [SerializeField] private GameObject ratonMov;
    [SerializeField] private CursorType cursor;// Default, Ventilador, Estufa;

    private Animator anim;

    private bool inicio;

    private float distance;

    public static bool MovActivado, ventiladorActivado, EstufaActivado;

    public static bool CanMove;
    public static bool posicionInicio = true;

   // public AudioSource _sonidoMoverse;

    public float posAnteriorX;

   // public DialogueUI dialogueUi;
   // public GameObject HUD_Manager;
    //public CanvasGroup HUDgroup;

    void Awake()
    {
        
    }

    void Start()
    {
        
        //texto.SetActive(true);
        MainCamera = Camera.main;
        inicio = true;
        maxSpeed = 7;
        anim = GetComponent<Animator>();
        MovActivado = false;
        CanMove = true;
        //GameObject objetoTextMeshPro = GameObject.Find("Espacio");
        //objetoTextMeshPro.SetActive(false);
    }

    void Update()
    {
        //if (posicionInicio == true)
        //{
        //    transform.position = new Vector3(-38.5f, 10.65f, 0);
        //}
        //Para el texto del principio
        /*if (Input.GetMouseButtonDown(0) && MovActivado)
        {
            texto.SetActive(false);
        }*/
        if (MovActivado == true && CanMove == true)
        {
            followMousePositionDelay(maxSpeed);
            //_sonidoMoverse.Play();
        }

        distance = Vector3.Distance(Player.transform.position, ratonMov.transform.position);

        /* if (distance <= 1)
         {
             maxSpeed = 0;
             anim.Play("MiniBot_Idle");
             //_sonidoMoverse.Stop();
         }

         if (distance < 2)
         {
             anim.Play("MiniBot_Idle");
         }

         if (distance > 2 && distance <= 3 && MovActivado == true)
         {
             maxSpeed = 1;
             anim.Play("miniBot_Caminar");
         }
         if (distance > 3 && distance <= 4 && MovActivado == true)
         {
             maxSpeed = 2;
             anim.Play("miniBot_Caminar");
         }
         if (distance > 4 && distance <= 5 && MovActivado == true)
         {
             maxSpeed = 3;
             anim.Play("miniBot_Caminar");
         }
         if (distance > 5 && distance <= 6 && MovActivado == true)
         {
             maxSpeed = 4;
             anim.Play("miniBot_Caminar");
         }
         if (distance > 6 && MovActivado == true)
         {
             maxSpeed = 6;
             anim.Play("miniBot_Caminar");
         }
         */



        if (inicio == true)
        {
            //transform.eulerAngles = new Vector3(0, 180, 0);
            Cursor.SetCursor(cursor.CursorTexture, cursor.CursorHotspot, CursorMode.Auto);
            StartCoroutine("Inicio");
        }

        /* if (ventiladorActivado == false && EstufaActivado == false)
         {
             if (transform.position.x > posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 180, 0);
                 Cursor.SetCursor(cursor.CursorTexture, cursor.CursorHotspot, CursorMode.Auto);
             }
             if (transform.position.x < posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 Cursor.SetCursor(cursor.CursorTexture, cursor.CursorHotspot, CursorMode.Auto);
             }
         }

         if (ventiladorActivado == true && EstufaActivado == false)
         {
             if (transform.position.x > posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 180, 0);
                 Cursor.SetCursor(Ventilador.CursorTexture, Ventilador.CursorHotspot, CursorMode.Auto);
             }
             if (transform.position.x < posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 Cursor.SetCursor(Ventilador.CursorTexture, Ventilador.CursorHotspot, CursorMode.Auto);
             }
         }
         if (EstufaActivado == true && ventiladorActivado == false)
         {
             if (transform.position.x > posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 180, 0);
                 Cursor.SetCursor(Estufa.CursorTexture, Estufa.CursorHotspot, CursorMode.Auto);
             }
             if (transform.position.x < posAnteriorX)
             {
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 Cursor.SetCursor(Estufa.CursorTexture, Estufa.CursorHotspot, CursorMode.Auto);
             }
         }*/

        posAnteriorX = transform.position.x;
    }

    private void OnMouseDown()
    {
        if(CanMove == true)
        {
            if (MovActivado == true)
            {
                MovActivado = false;
            }
            else if (MovActivado == false)
            {
                MovActivado = true;
               // Destroy(dialogueUi.ratonRueda);
               // Destroy(dialogueUi.textoRueda);
              //  Destroy(dialogueUi.ratonClickIzq);
               // Destroy(dialogueUi.textoActivarMov);
            }
        }
        
    }

    private void followMousePositionDelay(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private IEnumerator Inicio()
    {
        yield return new WaitForSeconds(3f);
        inicio = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "NivelActual")
        {
           // HUD_Manager = GameObject.Find("HUD_Manager");
          //  HUDgroup = HUD_Manager.GetComponent<CanvasGroup>();
            //HUD_Manager.SetActive(true);
           // HUDgroup.alpha = 1f;
        }
    }

}