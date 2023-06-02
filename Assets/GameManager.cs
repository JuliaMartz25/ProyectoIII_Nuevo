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

    void Update()
    {
        DictionaryAdd();
    }

    private void DictionaryAdd()
    {
        switch (text.text)
        {
            case "Hola":
                break;
            case "¡Buena suerte!":
                break;
            default:
                break;
        }
    }
}
