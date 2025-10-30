using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float launchSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var direction = transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction * launchSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);
    }
}