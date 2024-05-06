using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownDuration = 10f;
    public PlayerMovement player;
    public GameManager manager;
    public TextMeshProUGUI equationText;
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
                manager.ScoreUpdate();
            }
            UpdateTimerDisplay();
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
            equationText.text = $"Equation: y = {m}x + {b}";
            Debug.Log($"Timer started with equation: y = {m}x + {b}");

       
    }

    private void UpdateTimerDisplay()
    {
        equationText.text = $"Timer: {Mathf.CeilToInt(countdownTimer)}\nEquation: y = {m}x + {b}";
    }
}