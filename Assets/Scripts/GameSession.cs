using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI ScoreText;
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
    void Start()
    {
        lifeText.text = playerLife.ToString();
        ScoreText.text = score.ToString();
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
   public void AddScorePoint(int pointToAdd)
   {
        score += pointToAdd;
        ScoreText.text = score.ToString();
   }

    void TakeLife()
    {
        playerLife --;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lifeText.text = playerLife.ToString();
    }

    void ResetSession()
   {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
   }
}
