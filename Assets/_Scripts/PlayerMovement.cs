using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
//F = m*a
    [Tooltip("Fuerza de Movimiento del Perosnaje en N/s")]
    [Range(0,1000)]
    public float speed;

    [Tooltip("Fuerza de Rotación del Perosnaje en N/s")]
    [Range(0,360)]
    public float rotationSpeed;

    private Rigidbody rb;

    private void Start()
    {
       // Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // S = V*T
       float space = speed * Time.deltaTime;
       float horizontal = Input.GetAxis("Horizontal"); //-1 a 1
       float vertical = Input.GetAxis("Vertical"); //-1 a 1

       Vector3 dir = new Vector3(horizontal, 0, vertical);
      // transform.Translate(dir.normalized*space);
        //fuerza de translacion
        rb.AddRelativeForce(dir.normalized*space);
        
        
        float angle = rotationSpeed * Time.deltaTime;
       float mouseX = Input.GetAxis("Mouse X");
       //transform.Rotate(0,mouseX*angle,0);
       //Fuerza de rotación <-> torque
       rb.AddRelativeTorque(0, mouseX*angle,0);
       

    }
}
