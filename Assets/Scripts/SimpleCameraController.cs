using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public float rotationSpeed = 3.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(-mouseY, mouseX, 0);
    }
}
