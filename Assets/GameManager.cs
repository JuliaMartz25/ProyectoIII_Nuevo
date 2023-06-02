using Project.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //coger el objeto cuando empiece la conversacion, y cuando termine, elimino el collider y lo suelto 
    private GameObject collider;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] conversaciones;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DictionaryAdd();
    }

    private void DictionaryAdd()
    {
        print("hacieddo funcion");
        switch (text.text)
        {
            case "Hola":
                //collider.GetComponent<Collider2D>().enabled = true;
                break;
            case "¡Buena suerte!":
                print("inicio quitado collider");
                Destroy(PlayerDialogInteractor.col);
                print("quitado collider");
                break;
            default:
                print("entra switch");
                break;
        }
    }
}
