using UnityEngine;

public class Trolley_Anim : MonoBehaviour
{
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {


        animator.speed = PlayerInputs.currentSpeed / 4;
    }
}
