using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public GameObject camera;
    private Transform cameraTransform;
    
    private CharacterController controller;
    
    void Start()
    {
        cameraTransform = camera.GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
        Vector3 right = cameraTransform.TransformDirection(Vector3.right);
        Vector3 move = Input.GetAxis("Vertical") * forward + Input.GetAxis("Horizontal") * right;
        controller.Move(move * Time.deltaTime * moveSpeed);
    }
}
