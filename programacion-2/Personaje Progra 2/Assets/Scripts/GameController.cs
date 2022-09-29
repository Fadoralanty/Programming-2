using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public int finalScore;
    public Text score;
    public GameObject scoreScreen;

    private int startingScore = 0;
    public int currentScore;

    private void Start()
    {
        currentScore = startingScore;
    }

    private void Update()
    {
        ShowScoreOnScreen();
    }

    public int GetFinalScore()
    {
        finalScore = currentScore;
        return finalScore;
    }

    public void AddScoreWhenKillEnemy()
    {
        currentScore++;
    }

    private void ShowScoreOnScreen()
    {
        score.text = currentScore.ToString();
    }

    public void OpenScoreScreen()
    {
        Time.timeScale = 0;
        scoreScreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}