using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countdownTimer;
    public float maxTimer = 10f;

    public TextMeshProUGUI countdownTimerText;

    public LoadScene loadSceneScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdownTimer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;

        countdownTimerText.text = countdownTimer.ToString("F0");

        if (countdownTimer <= 0)
        {
            loadSceneScript.LoadGameOver();
        }
    }
}
