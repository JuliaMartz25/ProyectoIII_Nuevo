using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{

    public GameObject Camera;
    public float VelGiro;
    private bool PuedoGirar = false;
    public float Zeta;

    public Transform[] PuntosMov;
    public float speed;
    private int SiguientePaso = 0;

    private void Start()
    {
        StartCoroutine("Tiempo");
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Tiempo2");

        if (PuedoGirar == true)
        {
            Camera.transform.Rotate(new Vector3(0, 0, Zeta) * VelGiro * Time.deltaTime);
        }
        if (PuedoGirar == false)
        {
            Camera.transform.Rotate(new Vector3(0, 0, 0) * VelGiro * Time.deltaTime);
        }
    }

    public IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(5f);
        PuedoGirar = true;
        Zeta = Random.Range(-25, 25);

        yield return new WaitForSeconds(3f);
        PuedoGirar = false;

        yield return new WaitForSeconds(5f);
        PuedoGirar = true;
        Zeta = Random.Range(-25, 25);

        yield return new WaitForSeconds(3f);
        PuedoGirar = false;
        transform.position = Vector2.MoveTowards(transform.position, PuntosMov[SiguientePaso].position, speed * Time.deltaTime);
    }

    public IEnumerator Tiempo2()
    {
        yield return new WaitForSeconds(3f);
        transform.position = Vector2.MoveTowards(transform.position, PuntosMov[SiguientePaso].position, speed * Time.deltaTime);
    }


}
