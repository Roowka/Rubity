using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnCollected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
