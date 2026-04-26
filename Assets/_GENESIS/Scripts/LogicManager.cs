using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LogicManager : MonoBehaviour
{
    public static LogicManager instance;

    //NOTE: I revisited all the code in this mini project one week before the due date to add a "Press SPACE to start" screen and realized there are so many things I could have done better, code-wise.
    //I did not want to attempt to re-do it all and possibly break the code so close to the submission date, so I left 99% of it as is.
    //It's a VERY good sign I'm learning and getting better in the later 2nd and 3rd prototypes, night and day difference.
    //I am also aware it is usually not the best practice to use Singeltons in a player controller script, but since this is a singleplayer game with ONLY ONE player controller script active,
    //I decided to make use of a Singleton to more quickly polish up this mini-game and bring it up to standard for the submission with the limited time we have at this moment.

    [SerializeField] private int playerScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text titleText;
    [SerializeField] private Text startText;
    [SerializeField] private float startTextFlashInterval = 0.5f;
    [SerializeField] private bool gameStarted = false;
    [SerializeField] private bool canRestart = false;

    IEnumerator FlashStartText()
    {
        while (gameStarted == false)
        {
            startText.enabled = true;
            yield return new WaitForSeconds(startTextFlashInterval);

            startText.enabled = false;
            yield return new WaitForSeconds(startTextFlashInterval);
        }
    }

    IEnumerator EnableRestartAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        canRestart = true;
        startText.text = "Press 'SPACE' to Restart";
        startText.enabled = true;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        titleText.enabled = true;
        StartCoroutine(FlashStartText());
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void StartGame()
    {
        SFXManager.instance.PlayMusicClip(SFXManager.instance.musicPlaylist, transform, 0.1f);
        gameStarted = true;
        titleText.enabled = false;
        startText.enabled = false;
        scoreText.enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        SFXManager.instance.musicObject.Stop();
        SFXManager.instance.PlaySFXClip(SFXManager.instance.gameOverSFX, transform, 1f);
        PlayerController.instance.body.AddForceY(500);
        PlayerController.instance.isAlive = false;
        PlayerController.instance.capCollider.enabled = false;
        GameObject deathParticle = Instantiate(PlayerController.instance.deathParticle, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
        Destroy(deathParticle, 3);

        titleText.text = "GAME OVER";
        titleText.enabled = true;
        canRestart = false;
        StartCoroutine(EnableRestartAfterDelay());
    }

    public bool GetGameStartedStatus()
    {
        return gameStarted;
    }

    public bool GetCanRestart()
    {
        return canRestart;
    }
}
