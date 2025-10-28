using UnityEngine;

public class Background : MonoBehaviour
{
    float offset;
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset += (Time.deltaTime * PlayerInputs.currentSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0)); 
    }
}
