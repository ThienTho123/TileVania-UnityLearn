using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   public void ProcessPlayerDeath()
   {
        if(playerLife > 1)
        {
            Invoke(nameof(TakeLife),1);
        }
        else 
        {
            Invoke(nameof(ResetSession),1);
        }

   }

    void TakeLife()
    {
        playerLife --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetSession()
   {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
   }
}
