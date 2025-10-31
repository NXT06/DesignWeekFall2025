using UnityEngine;

public class Background : MonoBehaviour
{
    float offset;
    public float speedCut; 
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset += (Time.deltaTime * PlayerInputs.currentSpeed) / speedCut;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0)); 
    }
}
