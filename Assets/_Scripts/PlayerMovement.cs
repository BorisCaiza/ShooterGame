using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

    private Rigidbody _rb;
    private Animator _animator;
    private Animator _animator2;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator2 = GetComponent<Animator>();
        
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
        _rb.AddRelativeForce(dir.normalized*space);
        
        
        float angle = rotationSpeed * Time.deltaTime;
       float mouseX = Input.GetAxis("Mouse X");
       //transform.Rotate(0,mouseX*angle,0);
       //Fuerza de rotación <-> torque
       _rb.AddRelativeTorque(0, mouseX*angle,0);
       
      
       _animator.SetFloat("Velocity",_rb.velocity.magnitude);

       if (Input.GetKey(KeyCode.Space))
       {
           _animator2.SetTrigger("Jump");   
       }
       /*
        TODO: ajustar animaciones si se quieren usarse la de correr y caminar
          _animator.SetFloat("MoveX", horizontal);
          _animator.SetFloat("MoveY", vertical);
   
          if (Input.GetKey(KeyCode.LeftShift))
          {
              _animator.SetFloat("Velocity",_rb.velocity.magnitude);
          }
          else
          {
              if (Mathf.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01)
              {
                  _animator.SetFloat("Velocity",0);
              }
              else
              {
                  _animator.SetFloat("Velocity",0.15f);   
              }
             
             
          }*/

      


    }
}
