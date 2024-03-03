using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiscScript_ContinueUI : MonoBehaviour
{
    public TMP_Text killScoreUI;
    public TMP_Text timeScoreUI;
    public TMP_Text finalScoreUI;

    public MiscScript_ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<MiscScript_ScoreManager>();
    }
    public void Continue()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GetScores()
    {
        killScoreUI.text = "Kill Score: " + scoreManager.killScore;
        timeScoreUI.text = "Time Score: " + scoreManager.distanceScore;
        int finalScore = scoreManager.killScore + scoreManager.distanceScore;
        finalScoreUI.text = "Final Score: " + finalScore;
    }
}
