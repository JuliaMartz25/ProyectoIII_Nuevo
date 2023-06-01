using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitePlayer : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private GameObject Player;
    [SerializeField] private float Posx;
    [SerializeField] private float Posy;
    [SerializeField] private float Posz;

    [SerializeField] private float NumX;
    [SerializeField] private float NumY;

   // public DialogueObject Mision;

    public static bool Bordes;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Bordes = false;
    }

    private void Update()
    {
        Posx = transform.position.x;
        Posy = transform.position.y;
        Posz = transform.position.z;

        if(Bordes == true)
        {
            StartCoroutine("DesactivarScript");
        }
    }

    private IEnumerator DesactivarScript()
    {
        Follow.MovActivado = false;
        yield return new WaitForSeconds(1);
        Bordes = false;
        Follow.MovActivado = true;
    }
}