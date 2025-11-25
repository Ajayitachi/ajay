using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothspeed = 0.125f; 
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        //transform.position = new Vector3(0, 0, -14);
    }

    void LateUpdate()//called after all Update() calls are finished, only used in single script witin {}
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, -95);
            transform.position = Vector3.Lerp(target.position, desiredPosition,  smoothspeed);
        }
    }
}

