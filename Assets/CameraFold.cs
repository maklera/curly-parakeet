using UnityEngine;

public class CameraFold : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new(0, 0, -10);

    private void FixedUpdate()
    {
        if (target == null)
            return;
        Vector3 desiredPosition = target.position + offset;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
