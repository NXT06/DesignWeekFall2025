using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float moveMultiplier; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-PlayerInputs.currentSpeed * moveMultiplier * Time.deltaTime, 0); 
    }
}
