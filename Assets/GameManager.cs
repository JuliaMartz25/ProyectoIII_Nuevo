using Project.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //coger el objeto cuando empiece la conversacion, y cuando termine, elimino el collider y lo suelto 
    private GameObject collider;
    [SerializeField] private TextMeshProUGUI text;
    private bool doOnce = true;
    void Update()
    {
        DictionaryAdd();
    }

    private void DictionaryAdd()
    {
       
        switch (text.text)
        {
            case "Snifff":
                if (doOnce)
                {
                   // PlayerDialogInteractor.pararInteraccionHastaPulsarBoton = false;
                    
                }
                doOnce = false;
                break;
            case "¡Buena suerte!":
                break;
            default:
                break;
        }
    }
 
}
