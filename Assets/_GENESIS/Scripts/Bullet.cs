using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy enemyHit;
    public float bulletDamage = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHit = other.gameObject.GetComponent<Enemy>();
            enemyHit.TakeDamage(bulletDamage);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
