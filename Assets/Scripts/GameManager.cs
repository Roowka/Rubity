using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public RupeeManager RupeeManager { get; private set; }
    
    public ScoreManager ScoreManager { get; private set; }
    
    public UIManager UIManager { get; private set; }
    
    public TimeManager TimeManager { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        
        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        UIManager = GetComponent<UIManager>();
        TimeManager = GetComponent<TimeManager>();
    }

    private void Start()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
    }
    
    private void TimeUpHandler()
    {
        StopGame();
    }

    public void StartGame()
    {
        TimeManager.ResetTime();
        UIManager.StartGame();
        ScoreManager.StartGame();
        TimeManager.StartTimer();
    }

    public void StopGame()
    {
        TimeManager.StopTimer();
        UIManager.StopGame();
        RupeeManager.StopGame();
    }
}
