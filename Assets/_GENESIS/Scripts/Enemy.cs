using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    Rigidbody2D body;
    HealthBar healthBar;
    PlayerController playerController;

    public float health = 100;
    public float maxHealth = 100;
    public float damage = 100;
    public float moveSpeed = 3;
    public float killDistance = 1;
    public GameObject player;
    public GameObject damagedParticle;
    public GameObject deathParticle;
    public bool isFacingLeft = false;

    [SerializeField] private int scoreWhenKilled;

    [SerializeField] private AudioResource hitSFX;
    [SerializeField] private AudioResource dieSFX;

    Vector2 facingLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.target = transform;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (isFacingLeft == false)
        {
            facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else
        {
            facingLeft = new Vector2(transform.localScale.x, transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > killDistance && playerController.isAlive)
        {
            Vector2 moveDir = direction;
            body.linearVelocity = moveDir * moveSpeed;

            if (moveDir.x < 0 && !isFacingLeft)
            {
                isFacingLeft = true;
                FacingFlip();
            }
            if (moveDir.x > 0 && isFacingLeft)
            {
                isFacingLeft = false;
                FacingFlip();
            }
        }
        else
        {
            if (playerController.isAlive)
            {
                LogicManager.instance.GameOver();
            }
        }
    }

    void FacingFlip()
    {
        if (isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        else
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        SFXManager.instance.PlaySFXClip(hitSFX, transform, 0.3f);

        if (damagedParticle != null)
        {
            GameObject newParticle = Instantiate(damagedParticle, transform.position, transform.rotation);
            Destroy(newParticle, 3);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathParticle != null)
        {
            GameObject newParticle = Instantiate(deathParticle, transform.position, transform.rotation);
            Destroy(newParticle, 3);
        }
        LogicManager.instance.AddScore(scoreWhenKilled);
        SFXManager.instance.PlaySFXClip(dieSFX, transform, 1f);
        Destroy(gameObject);
    }
}
