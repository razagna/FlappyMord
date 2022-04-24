using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

    public Text scoreText;
    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countDownPage;

    enum PageState{None, Start, GameOver, Countdown}

    public bool GameOver { get; private set; } = true;
    public int Score { get; private set; } = 0;

    void Awake()
    {
        Instance = this;
    }

    void SetPageState(PageState state)
    {
        switch(state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countDownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countDownPage.SetActive(true);
                break;

        }
    }

    void OnEnable()
    {
        CountDownText.OnCountdownFinished += OnCountdownFinished;      
        TabController.OnPlayerScored += OnPlayerScored;
        TabController.OnPlayerDied += OnPlayerDied;
    }

    void OnDisable()
    {
        CountDownText.OnCountdownFinished -= OnCountdownFinished;     
        TabController.OnPlayerScored -= OnPlayerScored;
        TabController.OnPlayerDied -= OnPlayerDied;
    }

    void OnCountdownFinished()
    {
        SetPageState(PageState.None);
        OnGameStarted(); //event is sent to Tab Controller
        Score = 0;
        GameOver = false;
    }

    void OnPlayerDied()
    {
        GameOver = true;
        int savedScored = PlayerPrefs.GetInt("Highscore");
        if(Score > savedScored)
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
        SetPageState(PageState.GameOver);
    }

    void OnPlayerScored()
    {
        Score++;
        scoreText.text = Score.ToString();
    }

    public void StartGame()
    {
        SetPageState(PageState.Countdown);
    }

    public void ConfirmGameOver()
    {
        OnGameOverConfirmed(); //event is sent to Tab Controller
        scoreText.text = "0";
        SetPageState(PageState.Start);
    }

}
