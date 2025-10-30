using UnityEngine;

public class DetectRail : MonoBehaviour
{
  
    public Vector2 size;
    public LayerMask railLayer; 
    public bool CheckRail()
    {
        if(Physics2D.OverlapBox(transform.position + Vector3.right * PlayerInputs.currentSpeed, size, 0, railLayer))
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
        Gizmos.DrawWireCube(transform.position + Vector3.right * PlayerInputs.currentSpeed, size);
    }
}
