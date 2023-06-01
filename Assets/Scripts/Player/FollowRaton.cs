using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRaton : MonoBehaviour
{
    private Camera MainCamera;

    [SerializeField] private float maxSpeed = 7;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        followMousePositionDelay(maxSpeed);
    }

    private void followMousePositionDelay(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}
