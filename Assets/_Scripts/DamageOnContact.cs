using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
  
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        //Destroy(gameObject); prohibido object pooling es mejor.
        gameObject.SetActive(false); //Desactiva la bala
        //Destroy(other.gameObject); //Destrueye todo el objetivo

        /*if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }*/

        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.Amount -= damage;  //life.ampunt = life.amount - damage;     
        }

       



    }
}
