using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance;
    public Text score;
    int scoreAtual;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        scoreAtual += points;
        score.text = "SCORE: " + scoreAtual;
    }
}
