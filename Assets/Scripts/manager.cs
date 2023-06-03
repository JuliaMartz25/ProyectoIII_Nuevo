using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    public static GameObject particulas(Vector3 pos)
    {
        GameObject part = GameObject.Find("particulas");
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulas(Clone)"), 2);
        return part;
    }
    public static GameObject particulasScale(Vector3 pos, Vector3 scale)
    {
        GameObject part = GameObject.Find("particulas");
        GameObject partestr = GameObject.Find("estrellitas");
        part.transform.localScale = scale;
        partestr.transform.localScale = scale;
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulas(Clone)"), 2);
        return part;
    }
    public static GameObject particulasHumo(Vector3 pos)
    {
        GameObject part = GameObject.Find("particulasHumo");
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulasHumo(Clone)"), 2);
        return part;
    }
    public static GameObject particulasTamano(Vector3 pos, Vector3 scale)
    {
        GameObject part = GameObject.Find("particulasHumo");
        part.transform.localScale = scale;
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulasHumo(Clone)"), 2);
        return part;
    }
   

    public static GameObject particulasOscuras(Vector3 pos, Vector3 scale)
    {
        GameObject part = GameObject.Find("particulasHumoNegro");
        part.transform.localScale = scale;
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulasHumoNegro(Clone)"), 2);
        return part;
    }
    public static GameObject particulasHidra(Vector3 pos, Vector3 scale)
    {
        GameObject part = GameObject.Find("particulas_muerte_hidra");
        part.transform.localScale = scale;
        Instantiate(part, pos, Quaternion.identity);
        Destroy(GameObject.Find("particulas_muerte_hidra(Clone)"), 2);
        return part;
    }

}
