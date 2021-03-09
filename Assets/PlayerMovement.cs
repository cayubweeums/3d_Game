using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float rotationSpeed;

    private int upDownRotation = 0;

    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            upDownRotation = 1;
        } else if (Input.GetKey("e"))
        {
            upDownRotation = -1;
        } else
        {
            upDownRotation = 0;
        }

        // Rotation
        transform.Rotate(upDownRotation * rotationSpeed, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = moveSpeed * Input.GetAxis("Vertical");
        controller.Move(forward * curSpeed * Time.deltaTime);
    }
}
