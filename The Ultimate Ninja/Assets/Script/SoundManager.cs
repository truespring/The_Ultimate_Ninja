using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource audioSource;

    private void Awake() => Instance = this;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip soundShoot;

    public void SoundShoot()
    {
        audioSource.PlayOneShot(soundShoot);
    }
}