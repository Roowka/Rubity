using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public RupeeManager RupeeManager { get; private set; }
    
    public ScoreManager ScoreManager { get; private set; }
    
    public UIManager UIManager { get; private set; }
    
    public TimeManager TimeManager { get; private set; }
    
    public AudioManager AudioManager { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        
        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        UIManager = GetComponent<UIManager>();
        TimeManager = GetComponent<TimeManager>();
        AudioManager = GetComponent<AudioManager>();
    }
    
    private void TimeUpHandler()
    {
        StopGame();
    }

    public void StartGame()
    {
        TimeManager.OnTimeUp += TimeUpHandler;
        
        TimeManager.ResetTime();
        UIManager.StartGame();
        ScoreManager.StartGame();
        AudioManager.StartGame();
        TimeManager.StartTimer();
    }

    public void StopGame()
    {
        TimeManager.OnTimeUp -= TimeUpHandler;
        
        TimeManager.StopTimer();
        UIManager.StopGame();
        AudioManager.StopGame();
        RupeeManager.StopGame();
    }
}
