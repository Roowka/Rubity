using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;
    public float speed = 9f;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        _velocity = new Vector2(x, y).normalized;
        _rigidbody2D.linearVelocity = _velocity * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
