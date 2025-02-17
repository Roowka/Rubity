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
   private readonly List<Rupee> _rupees = new List<Rupee>();
   private Coroutine _spawnRoutine;
   
   public event Action<Rupee> OnRupeeCollected;

   private void Start()
   {
      StartSpawning();
   }

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
      var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
      rupee.transform.parent = container;
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
   }

   private void RupeeCollectedHandler(Rupee rupee)
   {
      OnRupeeCollected?.Invoke(rupee);
      RemoveRupee(rupee);
   }
}
