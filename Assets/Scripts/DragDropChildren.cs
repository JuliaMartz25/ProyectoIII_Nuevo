using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropChildren : MonoBehaviour
{
    //cuidado con las colisiones, si esta colisionando con otro objeto no funciona (al menos las basuras)
    public bool moving;

    private Renderer renderer;
    public Material mat, mat1;
    private float startposX, startposY;
    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        renderer.material.SetInt("_off", 1);
    }
  
    void FixedUpdate()
    {
        //movimiento del objeto
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            gameObject.transform.localPosition =
            new Vector3(mousePos.x - startposX, mousePos.y - startposY,this.transform.localPosition.z);
           
        }
    }

    private void OnMouseDown()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startposX = mousePos.x - this.transform.localPosition.x;
            startposY = mousePos.y - this.transform.localPosition.y;

        }
    }
    //activa el outline
    private void OnMouseEnter()
    {
        renderer.material = mat1;
        renderer.material.SetInt("_off", 0);
        renderer.material.SetInt("_pulso", 0);
    }
    //hace que no se puede mover
    private void OnMouseUp()
    {
        moving = false;
    }
    //desactiva el outline
    private void OnMouseExit()
    {
        renderer.material = mat;
    }
}
