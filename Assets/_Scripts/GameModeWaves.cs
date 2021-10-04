using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;
    
    [SerializeField]
    private Life baseLife;
    
    // Start is called before the first frame update
    private void Start()
    {
       playerLife.onDeath.AddListener(CheckLoseCondition);
       baseLife.onDeath.AddListener(CheckLoseCondition);
       
       EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
       WaveManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckLoseCondition()
    {
        //Perder

        
            SceneManager.LoadScene("WinScene",LoadSceneMode.Single);
        
    }

    void CheckWinCondition()
    {
        //Ganar
        if (EnemyManager.SharedInstance.GetEnemyCount <= 0 && 
            WaveManager.SharedInstance.WavesCount <= 0)
        {
            SceneManager.LoadScene("LoseScene",LoadSceneMode.Single);
        }
    }

   
}
