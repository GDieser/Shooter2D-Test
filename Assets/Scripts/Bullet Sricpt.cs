using System;
using UnityEngine;

public class BulletSricpt : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    [SerializeField] private AudioClip sound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveJhon jhon = collision.gameObject.GetComponent<MoveJhon>();
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

        if(jhon != null)
        {
            jhon.Hit();
            DestroyBullet();
        }
        else if (enemy != null)
        {
            enemy.Hit();
            DestroyBullet();
        }
        else
        {
            DestroyBullet();
        }

    }

}
