using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //coger el objeto cuando empiece la conversacion, y cuando termine, elimino el collider y lo suelto 
    private TextMeshProUGUI text;
    [SerializeField] private string[] conversaciones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DictionaryAdd()
    {

        switch (text.text)
        {
            case "¡Buena suerte!":
            default:
                break;
        }
    }
}
