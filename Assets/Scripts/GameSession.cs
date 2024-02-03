using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float playerLife = 3f;
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
            TakeLife();
        }
        else 
        {
            ResetSession();
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
   }
}
