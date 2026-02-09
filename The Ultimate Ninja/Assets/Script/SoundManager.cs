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
    public AudioClip soundScarecrowDeath;
    public AudioClip upgradeNinjaStar;
    public AudioClip upgradeScarecrow;
    public AudioClip soundSpecial;

    public void SoundShoot()
    {
        audioSource.PlayOneShot(soundShoot);
    }

    public void SoundScarecrowDeath()
    {
        audioSource.PlayOneShot(soundScarecrowDeath);
    }

    public void SoundUpgradeNinjaStar()
    {
        audioSource.PlayOneShot(upgradeNinjaStar);
    }

    public void SoundUpgradeScarecrow()
    {
        audioSource.PlayOneShot(upgradeScarecrow);
    }
    
    public void SoundSpecial()
    {
        audioSource.PlayOneShot(soundSpecial);
    }
}