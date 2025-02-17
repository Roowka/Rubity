using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
   public Transform spawner;
   public Transform container;
   public Rupee prefab;
   public float spawnDelay = 2f;
   public List<RupeeData> rupeeDataList = new List<RupeeData>();
   private readonly List<Rupee> _rupees = new List<Rupee>();
   private Coroutine _spawnRoutine;
   
   public event Action<Rupee> OnRupeeCollected;

   public void StartSpawning()
   {
      _spawnRoutine = StartCoroutine(SpawnRoutine());
   }
   
   private IEnumerator SpawnRoutine()
   {
      Spawn();
      yield return new WaitForSeconds(spawnDelay);
      StartSpawning();
   }

   private void Spawn()
   {
      var data = rupeeDataList[UnityEngine.Random.Range(0, rupeeDataList.Count)];
      var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
      rupee.transform.parent = container;
      rupee.Data = data;
      AddRupee(rupee);
   }

   private void AddRupee(Rupee rupee)
   {
      rupee.OnCollected += RupeeCollectedHandler;
      _rupees.Add(rupee);
   }

   private void RemoveRupee(Rupee rupee)
   {
      rupee.OnCollected -= RupeeCollectedHandler;
      _rupees.Remove(rupee);
      Destroy(rupee.gameObject);
   }

   private void StopSpawning()
   {
      if (_spawnRoutine == null) return;
      StopCoroutine(_spawnRoutine);
      _spawnRoutine = null;
   }

   public void StopGame()
   {
      StopSpawning();

      for (var i = _rupees.Count - 1; i >= 0; i--)
      {
         RemoveRupee(_rupees[i]);
      }
      
      _rupees.Clear();
   }

   private void RupeeCollectedHandler(Rupee rupee)
   {
      OnRupeeCollected?.Invoke(rupee);
      RemoveRupee(rupee);
   }
}
