using UnityEngine;
using static UnityEditor.Rendering.ShadowCascadeGUI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Jhon;
    private float LastShoot;

    [SerializeField] private GameObject bullet;
    private int Health = 3;

    void Update()
    {
        if (Jhon == null) return;

        Vector3 direction = Jhon.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Jhon.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject Bullet = Instantiate(bullet, (transform.position + direction * 0.1f), Quaternion.identity);
        Bullet.GetComponent<BulletSricpt>().SetDirection(direction);
    }

    public void Hit()
    {
        Health--;
        if (Health <= 0)
            Destroy(gameObject);
    }

}
