using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personalizacionBotDragDrop : MonoBehaviour
{
    public int posicion;
    public GameObject correctForm;
    public float correct;
    private DragDropChildren dragdrop;
    private bool haciendoColision = true;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private AudioSource _hecho;
    public Material mat;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        dragdrop = GetComponent<DragDropChildren>();
    }

    void Update()
    {
        dragPersonalizacion();
    }
    public void dragPersonalizacion()
    {
        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x)
       <= correct && Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= correct)
        {
            if (haciendoColision)
            {
                this.transform.localPosition =
            new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
                bool part_act = true;
                if (part_act)
                    manager.particulasTamano(this.transform.position, new Vector3(1, 1, 1));
                part_act = false;
                renderer.material = mat;
                _hecho.enabled = true;
                Destroy(dragdrop);
                
                agrandar_comic.conteoPiezas++;
                haciendoColision = false;

            }

        }
    }
}
