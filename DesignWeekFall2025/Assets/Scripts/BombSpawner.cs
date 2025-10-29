using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    public float cooldownTimer;
    public float cooldownMaxTime = 0.5f;
    public TextMeshProUGUI cooldownTimerText;

    private bool isBombSpawned = false;

    void Start()
    {
        cooldownTimer = 0f;
    }

    void Update()
    {
        cooldownTimerText.text = cooldownTimer.ToString("F2");

        cooldownTimer -= Time.deltaTime;
        
        if (cooldownTimer <= 0f)
        {
            cooldownTimer = 0;
        }

        if (Input.GetMouseButtonDown(0) & cooldownTimer <= 0f)
        {
            isBombSpawned = true;
        }

        if (isBombSpawned)
        {
            SpawnBomb();
            cooldownTimer = cooldownMaxTime;
            isBombSpawned = false;
        }
    }

    private void SpawnBomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}