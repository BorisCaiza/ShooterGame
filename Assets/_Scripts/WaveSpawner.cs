using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Tooltip("Prefab de enemigo a generar")]
    public GameObject prefab;
    [Tooltip("Tiempo en el que se inicia y fianliza la oleada")]
    public float startTime, endTime;

    [Tooltip("Teimpo entre la generación de enemigos")]
    public float spawnRate;
    //Cantidad de enemeigos <-> tiempo de inico/ tiemmpo fin
    // timepo entre enemigos
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        WaveManager.SharedInstance.waves.Add(this);
        InvokeRepeating("SpawnEnemey",startTime, spawnRate);
        Invoke("EndWave",endTime);
    }

    // Update is called once per frame

    void SpawnEnemey()
    {
      /*  Quaternion q = Quaternion.EulerAngles(0,
            transform.rotation.eulerAngles.y + Random.Range(-45.0f,45.0f), 0);*/
        
        Instantiate(prefab, transform.position, transform.rotation);
        
    }

    void EndWave()
    {
        WaveManager.SharedInstance.waves.Remove(this);
        CancelInvoke();
    }
}
