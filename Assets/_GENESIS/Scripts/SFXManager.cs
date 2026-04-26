using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] public AudioSource SFXObject;
    [SerializeField] public AudioSource musicObject;

    [SerializeField] public AudioResource musicPlaylist;
    [SerializeField] public AudioResource gameOverSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioResource audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.resource = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, 5);
    }

    public void PlayMusicClip(AudioResource audioClip, Transform spawnTransform, float volume)
    {
        musicObject.resource = audioClip;
        musicObject.volume = volume;
        musicObject.Play();
    }
}
