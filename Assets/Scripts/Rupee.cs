using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
