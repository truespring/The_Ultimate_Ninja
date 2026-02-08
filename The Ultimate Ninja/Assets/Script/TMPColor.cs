using System.Collections;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.1f;
    private TextMeshProUGUI _textMeshPro;
    private bool _isRunning = false;
    private Coroutine _lerpCoroutine;

    private void Awake() => _textMeshPro = GetComponent<TextMeshProUGUI>();

    public void OnActivate()
    {
        if (_textMeshPro == null) _textMeshPro = GetComponent<TextMeshProUGUI>();

        if (_isRunning) return;
        _lerpCoroutine = StartCoroutine("ColorLerpLoop");
    }

    public void StopTrigger()
    {
        StopCoroutine(_lerpCoroutine);

        _isRunning = false;

        _textMeshPro.color = Color.black;
    }

    private IEnumerator ColorLerpLoop()
    {
        _isRunning = true;
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

        while (percent < 1.0f && _isRunning)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            _textMeshPro.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}