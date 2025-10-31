using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;

    public float cooldownTimer;
    public float cooldownMaxTime = 0.5f;
    public float maxBombCount = 5;
    public float amountOfBombs;

    //public TextMeshProUGUI cooldownTimerText;
    public TextMeshProUGUI bombCountText;

    private bool isBombSpawned = false;

    void Start()
    {
        cooldownTimer = 0.5f;

        amountOfBombs = maxBombCount;
    }

    void Update()
    {
        //cooldownTimerText.text = cooldownTimer.ToString("F2");
        bombCountText.text = amountOfBombs.ToString();

        cooldownTimer -= Time.deltaTime;
        

        if (Input.GetMouseButtonDown(0) & cooldownTimer <= 0f & amountOfBombs > 0f)
        {
            isBombSpawned = true;
        }

        if (isBombSpawned)
        {
            SpawnBomb();
            Bombcount();
            cooldownTimer = cooldownMaxTime;
            isBombSpawned = false;
        }
    }

    private void SpawnBomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);
    }

    public void Bombcount()
    {
        amountOfBombs -= 1;
    }
}