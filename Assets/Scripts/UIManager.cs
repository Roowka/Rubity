using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public TextMeshProUGUI score;
   public TextMeshProUGUI bestScore;
   public TextMeshProUGUI timer;
   public GameObject startButton;
   private GameManager _gm;
   
   private void Awake()
   {
      _gm = GameManager.Instance;
   }

   private void Update()
   {
      score.text = $"Score: {_gm.ScoreManager.Score}";
      bestScore.text = $"Highest: {_gm.ScoreManager.BestScore}";
      timer.text = $"{TimeSpan.FromSeconds(_gm.TimeManager.RemaningTime):mm\\:ss}";
   }

   public void StartGame()
   {
      startButton.SetActive(false);
   }

   public void StopGame()
   {
      startButton.SetActive(true);
   }
}
