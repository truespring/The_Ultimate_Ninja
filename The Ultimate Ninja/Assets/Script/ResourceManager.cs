using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Button btnSoundShoot;
    public Button btnSoundScarecrowDeath;
    public Button btnSoundUpgradeNinjaStar;
    public Button btnSoundUpgradeScarecrow;
    public Button btnSoundSpecial;

    private void Start()
    {
        var soundManager = SoundManager.Instance;
        if (btnSoundShoot != null)
            btnSoundShoot.onClick.AddListener(soundManager.SoundShoot);
        if (btnSoundScarecrowDeath != null)
            btnSoundScarecrowDeath.onClick.AddListener(soundManager.SoundScarecrowDeath);
        if (btnSoundUpgradeNinjaStar != null)
            btnSoundUpgradeNinjaStar.onClick.AddListener(soundManager.SoundUpgradeNinjaStar);
        if (btnSoundUpgradeScarecrow != null)
            btnSoundUpgradeScarecrow.onClick.AddListener(soundManager.SoundUpgradeScarecrow);
        if (btnSoundSpecial != null)
            btnSoundSpecial.onClick.AddListener(soundManager.SoundSpecial);
    }
}