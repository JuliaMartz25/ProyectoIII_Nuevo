using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class oscurecer : MonoBehaviour
{
    public static bool remolinoFuera, FaseFinal;
    public Material mat;
    public Color colorLerp;
    public Color colorLerpRemolinoInicial;
    public Color colorLerpRemolinoFinal;
    public SpriteRenderer renderRemolino,remolinoPeque;
    //cambiar de color cuando se quita toda la basura, y cuando se quitan todos los remolinos
    public Color[] colores;
    private int siguienteColor;
    private SpriteShapeRenderer shapeRenderer;
    [SerializeField] public static int basura_cont;
    [SerializeField] private GameObject remolino;
    private float tiempo, colorStartTime;
    public float colorFadeDuration;
    private bool stopTiempo, eventoBasuraLimpia, oscurecerFinal, cFadeLagoNivel;
    public static bool MinijuegoOff = true;
    public GameObject _medidor;
    public Collider2D colConverNegro;
    [SerializeField] private bool part_act = true;
    //tocar cuando este el sistema de dialogo
  /*  [SerializeField] private ActivarBocadillo bocadillo;
    [SerializeField] private DialogueObject dialogo;
    public ObjectiveManager objectiveManager;
    public DialogueUI dialogueUi;*/

    public GameObject Tornado;

    public static int ContadorNegrosNormalizados;
    public static bool dialogoMostrado = false, EmpezarDialogo2 = false;
    public static bool terminado;
    public static bool interactuando;

    public CapsuleCollider2D colliderPlayer;
    public CambioCamara1 cambioCamara1;
    public GameObject HUD_Manager;
    public CanvasGroup HUDgroup;
    //public Canvas HUD_Manager;
    public Mov_Flechas_Final movFlechas;

    private void Start()
    {
        cFadeLagoNivel = false;
        oscurecerFinal = true;
        stopTiempo = false;
        eventoBasuraLimpia = true;
        renderRemolino.color = new Color32(255, 255, 255, 0);
        colConverNegro.enabled = false;
        FaseFinal = false;
        basura_cont = 0;
        shapeRenderer = GetComponent<SpriteShapeRenderer>();
        mat.color = colores[0];
        mat.SetColor("_emision", colores[0]);
        ContadorNegrosNormalizados = 0;

    }
    void Update()
    {
        print("Numero iluminados " + ContadorNegrosNormalizados);

        if (cFadeLagoNivel == false)
        {
            colorStartTime = Time.time;
        }
        //cuando quitas toda la basura cambia de color
        if (basura_cont == 7 && !stopTiempo /*&& MinijuegoOff == false*/)
        {
            print("Evento Basura limpia");
            tiempo += 0.2f * Time.deltaTime;
            colorLerp = Color.Lerp(colores[0], colores[1], tiempo);
            mat.SetColor("_emision", colorLerp);
            colConverNegro.enabled = true;
            renderRemolino.color = Color.Lerp(colorLerpRemolinoInicial, colorLerpRemolinoFinal, tiempo);
            remolinoPeque.color = Color.Lerp(colorLerpRemolinoInicial, colorLerpRemolinoFinal, tiempo);
            //bocadillo.ActivarDialogo();
            Tornado.SetActive(true);

            if(eventoBasuraLimpia == true)
            {
                
              /*  dialogueUi.ratonArrastrar.SetActive(false);
                dialogueUi.ratonArrastrarGeneral.SetActive(false);
                objectiveManager.AvanceEventos();
                objectiveManager.StartCoroutine("AvanceObjetivos");*/
                eventoBasuraLimpia = false;
                colliderPlayer.enabled = true;
                cambioCamara1.Camara1.SetActive(false);
                Destroy(cambioCamara1.gameObject);
            }

        }
        if(ContadorNegrosNormalizados == 7)
        {
            print("todos iluminados");
                if (cFadeLagoNivel == true)
            {
                float t = (Time.time - colorStartTime) / colorFadeDuration;
                colorLerp = Color.Lerp(colores[2], colores[3], t);
                mat.SetColor("_emision", colorLerp);

                if (t >= 1.0f)
                {
                    cFadeLagoNivel = false;
                }
            }
            /*tiempo = 0.2f;
            colorLerp = Color.Lerp(colores[2], colores[3], tiempo);*/
            if (oscurecerFinal == true)
            {
                oscurecerFinal = false;
                cFadeLagoNivel = true;
               /* dialogueUi.ratonIluminarGeneral.SetActive(false);
                objectiveManager.AvanceEventos();
                objectiveManager.MenuObjetivos();
                objectiveManager.StartCoroutine("AvanceObjetivos");*/
                terminado = false;
           /*     dialogueUi = FindObjectOfType<DialogueUI>();
                Follow.MovActivado = false;
                Follow.CanMove = false;*/
                //GameObject objetoTextMeshPro = GameObject.Find("Espacio");
                //objetoTextMeshPro.SetActive(true);
                //Cada numero de dialogo indica que solo se va a ejecutar una vez y para evitar la repeticion se usara un numero en especifico para que al entrar en collider, el script lo reconozca y lo ejecute una vez.
                //MedidorManager.MedidorCompleto = true;
                //mirar esto porque sino el cambio de color se hace 1 vez
                //ContadorNegrosNormalizados = 0;
                StartCoroutine("HablaFinalTuto");
            }
            
        }
        if (tiempo >= 1 && !stopTiempo)
        {
            stopTiempo = true;
            tiempo = 0;
        }
        if (tiempo >= 0.5f)
        {
            StartCoroutine("CanMove");
        }
        if (remolinoFuera)  // remolino fuera es la booleana que se pone despues de la conversacion con el habitante
        {
            print("remolino iluminado fuera");
            tiempo += 0.2f * Time.deltaTime;
            colorLerp = Color.Lerp(colores[1], colores[2], tiempo);
            renderRemolino.color = Color.Lerp(colorLerpRemolinoFinal, colorLerpRemolinoInicial, tiempo);
            remolinoPeque.color = Color.Lerp(colorLerpRemolinoFinal, colorLerpRemolinoInicial, tiempo);
            mat.SetColor("_emision", colorLerp);
            stopTiempo = true;
        }
    }
    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.1f);
        FaseFinal = false;
        MinijuegoOff = false;
        StopCoroutine("CanMove");
    }

    IEnumerator HablaFinalTuto()
    {
        yield return new WaitForSeconds(6.5f);
        Mov_Flechas_Final.nivelActual ++;
       /* Follow.CanMove = false;
        Follow.MovActivado = false;
        DialogueUI.numeroDialogo = 49;*/
        interactuando = true;
        dialogoMostrado = true;
        /*dialogueUi.ShowDialogue(dialogo);
        dialogueUi.contadorObjetivos.SetActive(false);
        dialogueUi.iconoGrisesIluminar.SetActive(false);*/
        HUDgroup.alpha = 0f;
        movFlechas.ValorMedidor = 30;
        movFlechas.ComprobColMedidor();
    }
}
