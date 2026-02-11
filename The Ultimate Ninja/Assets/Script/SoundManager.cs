using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource _sfxSource;
    private AudioSource _bgmSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _sfxSource = GetComponent<AudioSource>();
            _bgmSource = GetComponent<AudioSource>();
            _bgmSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioClip soundBGM;

    public AudioClip soundShoot;
    public AudioClip soundScarecrowDeath;
    public AudioClip upgradeNinjaStar;
    public AudioClip upgradeScarecrow;
    public AudioClip soundSpecial;

    private void Start()
    {
        SoundBGM();
    }

    public void SoundBGM()
    {
        if (_bgmSource.clip == soundBGM) return;
        _bgmSource.clip = soundBGM;
        _bgmSource.Play();
    }

    public void SoundShoot()
    {
        _sfxSource.PlayOneShot(soundShoot);
    }

    public void SoundScarecrowDeath()
    {
        _sfxSource.PlayOneShot(soundScarecrowDeath);
    }

    public void SoundUpgradeNinjaStar()
    {
        _sfxSource.PlayOneShot(upgradeNinjaStar);
    }

    public void SoundUpgradeScarecrow()
    {
        _sfxSource.PlayOneShot(upgradeScarecrow);
    }

    public void SoundSpecial()
    {
        _sfxSource.PlayOneShot(soundSpecial);
    }
}