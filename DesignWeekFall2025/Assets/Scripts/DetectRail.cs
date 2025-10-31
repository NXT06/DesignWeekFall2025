using UnityEngine;

public class DetectRail : MonoBehaviour
{
  
    public Vector2 size;
    public LayerMask railLayer;
    public Transform topRail; 
    public Transform bottomRail; 
    public bool CheckRail()
    {
        if(Physics2D.OverlapBox(transform.position, size, 0, railLayer))
        {
            return true; 
        }
        else
        {
            print("no Rail");
            return false;
        }
    }
    public bool CheckTop()
    {
        if(Physics2D.OverlapBox(topRail.position, size, 0, railLayer))
        {
            return true; 
        }
        else
        {
            print("no Rail");
            return false;
        }
    }
    public bool CheckBottom()
    {
        if(Physics2D.OverlapBox(bottomRail.position, size, 0, railLayer))
        {
            return true; 
        }
        else
        {
            print("no Rail");
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
        Gizmos.DrawWireCube(topRail.position, size);
        Gizmos.DrawWireCube(bottomRail.position, size);
    }
}
