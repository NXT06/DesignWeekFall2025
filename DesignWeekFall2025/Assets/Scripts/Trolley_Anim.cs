using UnityEngine;

public class Trolley_Anim : MonoBehaviour
{
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInputs.currentSpeed > 0f)
        {
            animator.SetBool("isMoving", true);
        }

        if (PlayerInputs.currentSpeed <= 0f)
        {
            animator.SetBool("isMoving", false);
        }
    }
}
