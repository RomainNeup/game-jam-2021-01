
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate () 
    {
        transform.position = target.position;
    }
}
