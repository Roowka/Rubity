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

    public void ResetTime()
    {
        RemaningTime = duration;
    }

    public void StartTimer()
    {
        IsRunning = true;
    }

    public void StopTimer()
    {
        IsRunning = false;
    }
}
