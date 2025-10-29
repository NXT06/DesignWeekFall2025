using UnityEngine;

public class DetectRail : MonoBehaviour
{
    Transform railPosition;
    Vector2 size;
    LayerMask railLayer; 
    public bool CheckRail()
    {
        if(Physics2D.OverlapBox(railPosition.position, size, 0, railLayer))
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
}
