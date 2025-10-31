using UnityEngine;

public class Explosion_Amin : MonoBehaviour
{
    public Animator animator;

    public float destoryTime;

    public bool exploding = true;
    public bool exploded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Exploding();
    }

    private void Exploding()
    {
        if (exploding)
        {
            animator.SetBool("isExploding", true);
            exploded = true;
        }

        if (exploded)
        {
            animator.SetBool("isExploding", false);
            exploding = false;
            Destroy(gameObject, destoryTime);
        }
    }
}
