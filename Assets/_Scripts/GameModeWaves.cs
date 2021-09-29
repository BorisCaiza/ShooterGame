using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ganar
        if (EnemyManager.SharedInstance.enemies.Count <= 0 && 
            WaveManager.SharedInstance.waves.Count <= 0)
        {
            SceneManager.LoadScene("LoseScene",LoadSceneMode.Single);
        }
        //Perder

        if (playerLife.Amount <=0)
        {
                SceneManager.LoadScene("WinScene",LoadSceneMode.Single);
        }
    }
}
