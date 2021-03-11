using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    //based on https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
    public float mouseSensitivity;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yaw += mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //lock vertical movement to 70 degrees
        pitch = Mathf.Clamp(pitch,-70, 70);

        this.transform.eulerAngles = new Vector3(pitch, yaw) ;
        
    }
}
