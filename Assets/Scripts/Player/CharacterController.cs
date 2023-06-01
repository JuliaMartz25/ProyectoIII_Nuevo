using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterController : MonoBehaviour
{
    Vector3 MousePosition;
    [SerializeField] private float moveSpeed = 0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2 (0f, 0f);

    [SerializeField] private CinemachineVirtualCamera myCamera;
    private float zoomSpeed = 50f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCamera.m_Lens.OrthographicSize = 5;
    }


    private void FixedUpdate()
    {
        zoom();
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        position = Vector2.Lerp(transform.position, MousePosition, moveSpeed);
        rb.MovePosition(position);
    }

    private void zoom()
    {
        if (Input.mouseScrollDelta.y != 0 )
        {
            myCamera.m_Lens.OrthographicSize -= Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed;
            myCamera.m_Lens.OrthographicSize = Mathf.Clamp(myCamera.m_Lens.OrthographicSize, 5, 10);
            
        }
    }
}
