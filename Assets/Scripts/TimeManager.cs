using System;
using Unity.IntegerTime;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float duration = 120f;
    public float RemaningTime { get; private set; }
    public bool IsRunning { get; private set; }
    public event Action OnTimeUp;

    private void Update()
    {
        if (IsRunning)
        {
            Tick(Time.deltaTime);
        }
    }

    private void Tick(float deltaTime)
    {
        RemaningTime -= deltaTime;
        
        if (RemaningTime < 0)
        {
            RemaningTime = 0;
            OnTimeUp?.Invoke();
        }
    }

    private void Start()
    {
        ResetTime();
        StartTimer();
    }

    private void ResetTime()
    {
        RemaningTime = duration;
    }

    private void StartTimer()
    {
        IsRunning = true;
    }

    private void StopTimer()
    {
        IsRunning = false;
    }
}
