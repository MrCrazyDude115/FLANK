using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //NOTE: I revisited all the code in this mini project one week before the due date to add a "Press SPACE to start" screen and realized there are so many things I could have done better, code-wise.
    //I did not want to attempt to re-do it all and possibly break the code so close to the submission date, so I left 99% of it as is.
    //It's a VERY good sign I'm learning and getting better in the later 2nd and 3rd prototypes, night and day difference.
    //I am also aware it is usually not the best practice to use Singeltons in a player controller script, but since this is a singleplayer game with ONLY ONE player controller script active,
    //I decided to make use of a Singleton to more quickly polish up this mini-game and bring it up to standard for the submission with the limited time we have at this moment.

    public static PlayerController instance;

    public Rigidbody2D body;
    public CapsuleCollider2D capCollider;

    public float moveSpeed = 5;
    public GameObject shootOrigin;
    public GameObject bullet;
    public float shotCooldown = 1f;
    float lastShotTime;
    public float bulletVelocity = 50;
    public GameObject deathParticle;
    public bool isAlive = true;

    [SerializeField] private AudioResource shootSFX;

    GameObject newBullet;
    bool isFacingLeft = false;

    Vector2 facingLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        capCollider = GetComponent<CapsuleCollider2D>();

        Init();
    }

    void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            if (isAlive && LogicManager.instance.GetGameStartedStatus())
            {
                if (lastShotTime + shotCooldown < Time.time)
                {
                    Shoot();
                }
            }
            else if (!LogicManager.instance.GetGameStartedStatus())
            {
                LogicManager.instance.StartGame();
            }
            else
            {
                if (LogicManager.instance.GetCanRestart())
                {
                    LogicManager.instance.RestartGame();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (LogicManager.instance.GetGameStartedStatus())
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (isAlive)
            {
                body.linearVelocityX = horizontalInput * moveSpeed;

                if (horizontalInput > 0 && isFacingLeft)
                {
                    isFacingLeft = false;
                    FacingFlip();
                }
                if (horizontalInput < 0 && !isFacingLeft)
                {
                    isFacingLeft = true;
                    FacingFlip();
                }
            }
        }
    }

    void Init()
    {
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
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

    void Shoot()
    {
        if (isFacingLeft)
        {
            GameObject newBullet = Instantiate(bullet, shootOrigin.transform.position, Quaternion.Euler(0,0,90));
            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.linearVelocity = -transform.right * bulletVelocity;
        }
        if (!isFacingLeft)
        {
            GameObject newBullet = Instantiate(bullet, shootOrigin.transform.position, Quaternion.Euler(0, 0, -90));
            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.linearVelocity = transform.right * bulletVelocity;
        }
        SFXManager.instance.PlaySFXClip(shootSFX, transform, 1f);
        lastShotTime = Time.time;
    }

    public bool GetPlayerIsAlive()
    {
        return isAlive;
    }
}

