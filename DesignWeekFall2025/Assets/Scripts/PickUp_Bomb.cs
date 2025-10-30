using Unity.VisualScripting;
using UnityEngine;

public class PickUp_Bomb : MonoBehaviour
{
    public BombSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("BombSpawner").GetComponent<BombSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Minecart"))
        {
            spawner.amountOfBombs += 1;
            Destroy(this.gameObject);
        }
    }
}
