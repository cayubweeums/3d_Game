using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public GameObject camera;
    private Transform cameraTransform;
    
    private Rigidbody body;
    private float vertical;
    private float horizontal;
    private Vector3 forward;
    private Vector3 right;
    
    void Start()
    {
        cameraTransform = camera.GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = cameraTransform.TransformDirection(Vector3.forward);
        right = cameraTransform.TransformDirection(Vector3.right);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 move = vertical * forward + horizontal * right;
        body.velocity = move * moveSpeed;
    }
}
