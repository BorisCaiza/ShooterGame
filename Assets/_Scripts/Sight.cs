using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayers;
    public LayerMask obstacleLayers;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);
        //Filtro de la distancia.
        foreach (Collider collider in colliders)
        {
            Vector3 directionToCollider = collider.bounds.center - transform.position;
            directionToCollider = Vector3.Normalize(directionToCollider);

            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            if (angleToCollider < angle)
            {
                //Copmorbamos que en la linea de vision del enemigo no haya obstaculos.
                if (!Physics.Linecast(transform.position, collider.bounds.center, obstacleLayers))
                {
                    
                }
            }



        }

       /* for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
        }*/
    }
}
