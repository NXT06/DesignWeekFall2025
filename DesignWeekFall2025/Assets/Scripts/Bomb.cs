using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float launchSpeed;

    public GameObject explosion;
    public GameObject bomb;

    public BombSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var direction = transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction * launchSpeed, ForceMode2D.Impulse);

        spawner = GameObject.FindGameObjectWithTag("BombSpawner").GetComponent<BombSpawner>();
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Rock"))
        {
            spawner.amountOfBombs += 1;
            Destroy(collision.gameObject);
            Debug.Log("Rock");
        }

        Destroy(bomb);
    }
}