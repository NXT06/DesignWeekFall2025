using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer background; 

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset = new Vector2(Time.time * PlayerInputs.currentSpeed, 0f); 
    }
}
