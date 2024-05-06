using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float countdownDuration = 3f;
  
    
    public LineGenerator lineGenerator;

    public bool timerStarted = false;

    private float countdownTimer;
    private int m;
    private int b;

    private bool isGameOver = false;
    public int linesGenerated = 0;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (timerStarted)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0f && !isGameOver)
            {
                timerStarted = false;
                GenerateLine();  // Generate the line when timer reaches zero
                ResetTimer();    // Reset the timer after generating the line
               
            }
            
        }
    }

    private void GenerateLine()
    {
        Debug.Log($"Generating line with equation: y = {m}x + {b}");
        lineGenerator.GenerateLine(m, b);
        linesGenerated++;

    }

    public void ResetTimer()
    {
        m = Random.Range(-2, 3);
        b = Random.Range(-5, 6);
        countdownTimer = countdownDuration;
        timerStarted = true;
        //generate equations
        Debug.Log($"Timer started with equation: y = {m}x + {b}");


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

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

}