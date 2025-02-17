using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public TextMeshProUGUI score;
   public TextMeshProUGUI timer;
   private GameManager _gm;
   
   private void Awake()
   {
      _gm = GameManager.Instance;
   }

   private void Update()
   {
      score.text = $"Score: {_gm.ScoreManager.Score}";
      timer.text = $"{TimeSpan.FromSeconds(_gm.TimeManager.RemaningTime):mm\\:ss}";
   }
}
