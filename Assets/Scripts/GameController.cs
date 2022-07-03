using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    int p_Score;
    bool p_GameOver;
    public float SpawnTime;
    float p_SpawnTime;
    UIManager p_UI;


    // Start is called before the first frame update
    void Start()
    {
        p_SpawnTime = 0;
        p_UI = FindObjectOfType<UIManager>();
        p_UI.setScoreText("Score: "+p_Score);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver())
        {
            p_UI.ShowGameOverPanel(true);
            p_UI.setScoreText("Score: " + getScore());
            p_SpawnTime = 0;            
            return;
        }

        p_SpawnTime -= Time.deltaTime;
        if (p_SpawnTime <= 0)
        {
            SpawnEnemy();
            p_SpawnTime = SpawnTime;
        }

    }

    public void setScore(int value)
    {
        p_Score = value;
    }
    public int getScore()
    {
        return p_Score;
    }

    public void ScoreIncresing()
    {
        if(IsGameOver())
        {
            return;
        }
        p_Score++;
        p_UI.setScoreText("Score: " + p_Score);
    }
    public void setGameOver(bool state)
    {
        p_GameOver = state;
    }
    public bool IsGameOver()
    {
        return p_GameOver;
    }

    //-8.8 < x<8.8
    //y>5.7
    public void SpawnEnemy()
    {
        float randXPos = Random.Range(-8.8f, 8.8f);
        Vector2 spawnPos = new Vector2(randXPos, 5.7f);
        if (Enemy)
        {
            Instantiate(Enemy, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("UIGame");
    }

}
