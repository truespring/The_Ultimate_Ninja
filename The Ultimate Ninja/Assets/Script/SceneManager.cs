using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ChangeToGameScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    public void ChangeToTitleScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    public void ChangeToCreditScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("CreditScene");
    public void ChangeToResourceScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("ResourceScene");
}