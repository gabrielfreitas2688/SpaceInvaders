using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManeger : MonoBehaviour
{
    public GameObject boss;
    public static GameManeger Instance;
    public Text score;
    public Text gameOver;
    public Text youWin;
    public Button tryAgain;
    public int enemyCounter = 0;
    int scoreAtual;

    private void Awake()
    {
        Instance = this;
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
        Debug.Log("Inimigos restantes: " + enemyCounter);

        if (enemyCounter <= 0)
        {
            
            BosSpawn();
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);

    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void Win()
    {
        Time.timeScale = 0;
        youWin.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);

    }

    public void CalcEnemys()
    {
        enemyCounter++;
    }

    void BosSpawn()
    {
        boss.gameObject.SetActive(true);
    }
}
