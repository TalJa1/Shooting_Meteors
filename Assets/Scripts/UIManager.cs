using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1.Hien thi diem so
//2.Hien thi thong bao
public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public GameObject GameOverPanel;

    public void setScoreText(string t)
    {
        if(ScoreText)
        {
            ScoreText.text = t;
        }
    }

    public void ShowGameOverPanel(bool isShow)
    {
        if(GameOverPanel)
        {
            GameOverPanel.SetActive(isShow);
        }
    }

}
