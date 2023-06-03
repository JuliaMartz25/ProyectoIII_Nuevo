using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bordes : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        SceneManager.LoadScene("Mocos");
    }

}
