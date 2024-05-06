using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public CountdownTimer timer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverText;
    public GameObject startGame;
    private int score;
    private int highScore;
    private bool isGameOver = false;
    public List<int> highScoresList = new List<int>();

    private bool gamePause = true;


    private void Start()
    {
        PauseGame();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gamePause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; //pause game
        gamePause = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; //resume
        gamePause = false;
        startGame.SetActive(false);
    }

    public void ScoreUpdate()
    {
        score += 10;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over");

            // Stop player 
            player.enabled = false;

            // Stop timer
            timer.timerStarted = false;

            // Display game over text
            gameOverText.SetActive(true);

            // Add the current score to the high scores list
            highScoresList.Add(score);

            // Sort the high scores list in descending order
            SortHighScoresList();

            // Save the high scores list to PlayerPrefs
            SaveHighScores();

            // Clear the current score
            score = 0;
        }
    }

    private void SortHighScoresList()
    {
        highScoresList.Sort((a, b) => b.CompareTo(a));
    }

    private void SaveHighScores()
    {
        string highScoresJson = JsonUtility.ToJson(highScoresList);
        PlayerPrefs.SetString("HighScores", highScoresJson);
    }

    public void Reset()
    {
        // Restart player movement
        player.transform.position = Vector3.zero;
        player.enabled = true;

        // Reset timer
        timer.ResetTimer();

        gameOverText.SetActive(false);

        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Exit game
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
}