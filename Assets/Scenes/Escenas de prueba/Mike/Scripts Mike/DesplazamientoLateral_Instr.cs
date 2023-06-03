using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoLateral_Instr : MonoBehaviour
{

    public GameObject ratonBlanco;

    private Vector3 miPosicionInicial, miPosicionFinal;

    [SerializeField] private float limitePosicion;
    [SerializeField] private float speed;

    private bool cambioDir;
    // Start is called before the first frame update
    void Start()
    {
        miPosicionInicial = transform.localPosition;
        miPosicionFinal = miPosicionInicial - new Vector3(limitePosicion, 0f, 0f);
        cambioDir = true;

        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoRaton();
    }

    private void MovimientoRaton()
    {
        if (transform.localPosition.x > miPosicionFinal.x && cambioDir == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        if (transform.localPosition.x <= miPosicionFinal.x)
        {
            cambioDir = false;
        }

        if (transform.localPosition.x < miPosicionInicial.x && cambioDir == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        if (transform.localPosition.x >= miPosicionInicial.x)
        {
            cambioDir = true;
        }
    }
}
