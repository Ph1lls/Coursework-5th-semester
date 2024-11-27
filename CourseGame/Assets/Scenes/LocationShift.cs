using UnityEngine;

public class LocationShift2D : MonoBehaviour
{
    public Vector2 shiftAmount;
    public Transform cameraTransform;
    private Vector3 initialCameraPosition;
    private bool hasShifted = false;

    private void Start()
    {
        if (cameraTransform != null)
        {
            initialCameraPosition = cameraTransform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasShifted)
            {
                if (cameraTransform != null)
                {
                    cameraTransform.position += new Vector3(shiftAmount.x, shiftAmount.y, 0);
                    hasShifted = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cameraTransform != null)
            {
                cameraTransform.position = initialCameraPosition;
                hasShifted = false; 
            }
        }
    }
}
