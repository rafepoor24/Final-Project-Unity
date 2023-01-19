using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]private float swayAmount=8;


    private Quaternion startRotation;


    void Start()
    {
        startRotation = transform.localRotation;
    }

   
    void Update()
    {
        Sway();
    }

    private void Sway()
    {
       float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Quaternion xAngle =Quaternion.AngleAxis(mouseX* -1.25f, Vector2.up);    

        Quaternion yAngle =Quaternion.AngleAxis(mouseY* -1.25f, Vector2.right);    

        Quaternion targetRotation=startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation,Time.deltaTime*swayAmount);

    }
}
