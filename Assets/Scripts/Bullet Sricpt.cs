using System;
using UnityEngine;

public class BulletSricpt : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        rb.linearVelocity = this.direction * speed;

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
