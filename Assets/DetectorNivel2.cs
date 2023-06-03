using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorNivel2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerFollow.NivelActual = 2;
        Destroy(this.gameObject);
    }

}
