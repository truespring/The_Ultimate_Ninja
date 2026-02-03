using System.Collections;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.1f;
    private TextMeshProUGUI _textMeshPro;
    private bool isRunning = false;
    
    private void Awake() => _textMeshPro = GetComponent<TextMeshProUGUI>();

    public void OnActivate()
    {
        if (_textMeshPro == null) _textMeshPro = GetComponent<TextMeshProUGUI>();
        
        if (isRunning) return;
        StartCoroutine("ColorLerpLoop");   
    }

    public void StopTrigger()
    {
        StopCoroutine("ColorLerpLoop");
        isRunning = false;
        _textMeshPro.color = Color.black;
    }

    private IEnumerator ColorLerpLoop()
    {
        isRunning = true;
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }
    
    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            _textMeshPro.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}
