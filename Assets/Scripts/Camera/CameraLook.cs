using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // handle the camera's sensivity
    [Header("Values")]
    [Tooltip("handle the camera's sensivity")][SerializeField]private float mouseSensivity = 80f;

    [Header("Components")]
    [Tooltip("Use the player position")][SerializeField]private Transform playerBody;



    private float mouseX;
    private float mouseY;
    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update()
    {
        mouseX=Input.GetAxis("Mouse X")*mouseSensivity*Time.deltaTime;

        mouseY = Input.GetAxis("Mouse Y")*mouseSensivity*Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up*mouseX);
    }
}
