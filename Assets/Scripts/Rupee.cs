using System;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    public event Action<Rupee> OnCollected;

    private RupeeData _data;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public RupeeData Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            _spriteRenderer.color = _data.color;
        }
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
