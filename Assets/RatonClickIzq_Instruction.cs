using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatonClickIzq_Instruction : MonoBehaviour
{
    public GameObject ratonBlanco, ratonClick;

    private bool anim;

    public float segundosEsperaInstr;

    // Start is called before the first frame update
    void Start()
    {
        anim = true;
        ratonBlanco.SetActive(true);
        ratonClick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("AnimClick");
    }

    IEnumerator AnimClick()
    {
        if (anim == true)
        {
            anim = false;
            yield return new WaitForSeconds(segundosEsperaInstr);
            ratonBlanco.SetActive(false);
            ratonClick.SetActive(true);
            yield return new WaitForSeconds(segundosEsperaInstr);
            ratonBlanco.SetActive(true);
            ratonClick.SetActive(false);
            anim = true;
        }
    }
}
