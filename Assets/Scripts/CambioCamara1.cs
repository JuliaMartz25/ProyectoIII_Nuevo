using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara1 : MonoBehaviour
{

    public GameObject CamaraDefault, Camara1;

    public ObjectiveManager objectiveManager;
 //  public DialogueUI dialogueUi;

    public CapsuleCollider2D colliderPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // dialogueUi.ratonArrastrar.SetActive(true);
            //dialogueUi.ratonArrastrarGeneral.SetActive(true);
           // dialogueUi.numeroAvanceObjetivo = 0;
          //  dialogueUi.numeroMetaObjetivo = 7;
          //  dialogueUi.textoContadorObjetivos.text = (dialogueUi.numeroAvanceObjetivo + " / " + dialogueUi.numeroMetaObjetivo);
            //dialogueUi.contadorObjetivos.SetActive(true);
            //dialogueUi.iconoBasuraArrastrar.SetActive(true);
            objectiveManager.StartCoroutine("AvanceObjetivos");
            Camara1.SetActive(true);
            //Follow.CanMove = false;
            //Follow.MovActivado = false;
            oscurecer.MinijuegoOff = false;
            //colliderPlayer.enabled = false;
            StartCoroutine("QuitarCollider");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Camara1.SetActive(false);
            //Destroy(this.gameObject);
        }

    }

    IEnumerator QuitarCollider()
    {
        yield return new WaitForSeconds(1f);
        colliderPlayer.enabled = false;
    }
}
