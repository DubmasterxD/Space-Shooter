using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
    }

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int points)
    {
        score += points;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
