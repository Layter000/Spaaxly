using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;


public class GameControl : MonoBehaviour {

    public GameObject [] player;
    public Transform playerPositionStart;

    public Action OnGameRestart;

    public static GameControl instance;
    public AudioController audioController;
    public GameObject gameOverUI;
    public GameObject gameOverAnimation;

    public Text [] scoreText;
    public Text [] totalScoreText;
    public Text topScoreText;

    public GameObject gameUI;
    public bool gameOver = false;
    public bool isPause = false;
    public bool isStart = false;
    public float scrollSpeed = -1.5f;
    public float scrollAddSpeed;
    public float scrollSpeedMax;
    public int totalScore;

    public bool isVolume;

    public int selectedCharacters;

    private int score;
    private int convertInt;
    private float scrollSpeedStart;
    private float flightdistance;
    private Animator anim;

    private int topScore = 0;

    private const string gameOverBaner = "ca-app-pub-7120188332170318/1667697985";
    private InterstitialAd ad;

    void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        anim = gameOverAnimation.GetComponent<Animator>();
        scrollSpeedStart = scrollSpeed;
        if (PlayerPrefs.HasKey("TotalScore") == true)
        {
            totalScore = PlayerPrefs.GetInt("TotalScore");
        }
        if (PlayerPrefs.HasKey("TopScore") == true)
        {
            topScore = PlayerPrefs.GetInt("TopScore");
        }
        if (PlayerPrefs.HasKey("selectedPlayer") == true)
        {
            selectedCharacters = PlayerPrefs.GetInt("selectedPlayer");
        }
        totalScoreText[0].text = "Total coins: " + totalScore.ToString();
        totalScoreText[1].text = "You coins: " + totalScore.ToString();
        RequestInterstitial();
    }
	void Update () {
        //Time.timeScale = 0.3f;
        if (scrollSpeed <= scrollSpeedMax && isPause == false && isStart == true)
        {
            scrollSpeed += scrollAddSpeed * Time.deltaTime;
        }
        if(isStart == true)
        {
            flightdistance += scrollSpeed*Time.deltaTime;
            gameUI.SetActive(true);
            scoreText[0].text = "Score: " + (int)flightdistance;
        }

        scoreText[1].text = "You score: " + (int)flightdistance;
        scoreText[2].text = "You score: " + (int)flightdistance;

        if (Input.GetKeyDown("space"))
        {
            totalScore += 500;
            PlayerPrefs.DeleteAll();
        }
    }
    public void PlayerDied()
    {
        anim.SetTrigger("GameOver");
        audioController.PlayGameOverSound();

        if(topScore < (int)flightdistance || topScore == 0)
        {
            topScore = (int)flightdistance;
            topScoreText.text = "New record!";
            PlayerPrefs.SetInt("TopScore", topScore);
        }
        else
        {
            topScoreText.text = "You record: " + topScore;
        }

        isStart = false;
        gameOver = true;
        gameUI.SetActive(false);
        StartCoroutine(GameOver());
    }
    public void PlayerScored()
    {
        score++;
        totalScore++;
        totalScoreText[0].text = "Total coins: " + totalScore.ToString();
        totalScoreText[1].text = "You coins: " + totalScore.ToString();
        SaveScore();
    }
    public void Restart()
    {
        if (OnGameRestart != null)
        {
            OnGameRestart();
        }
        gameOver = false;
        scrollSpeed = scrollSpeedStart;
        score = 0;
        flightdistance = 0;
        scoreText[0].text = "Coin: " + 0;
        if (isStart == true)
        {
            CreatePlayer();
        }
        RequestInterstitial();
    }
    public void selectedPlayer(int number)
    {
        selectedCharacters = number;
        PlayerPrefs.SetInt("selectedPlayer", selectedCharacters);
    }
    public void Pause()
    {
        if(isPause == false)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else if (isPause == true)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    public void StartGame(bool battonValue)
    {
        isStart = battonValue;
    }
    public void CreatePlayer()
    {
        Instantiate(player[selectedCharacters], playerPositionStart.transform.position, Quaternion.identity/*Euler(0, 0, 0)*/);
    }
    public void SaveScore()
    {
        
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.45f);
        gameOverUI.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        if (ad.IsLoaded())
        {
            ad.Show();
        }
    }
    public void OnAdloaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
    public void Cheat()
    {
        totalScore += 100;
    }
    private void RequestInterstitial()
    {
        ad = new InterstitialAd(gameOverBaner);
        AdRequest request = new AdRequest.Builder().Build();
        ad.LoadAd(request);
    }
    }
