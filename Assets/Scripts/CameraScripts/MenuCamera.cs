using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    // Variables to control the smoothness and intensity of the camera movement
    public float smoothSpeed = 5.0f;   // Speed of smoothing
    public float rotationAmount = 15.0f; // How much the camera will rotate based on the mouse position

    // Limits for rotation on both axes
    public Vector2 rotationXLimit = new Vector2(-10f, 10f);  // Min and max for X-axis rotation (up/down)
    public Vector2 rotationYLimit = new Vector2(-10f, 10f);  // Min and max for Y-axis rotation (left/right)

    // Current rotation values for the camera
    private float currentXRotation;
    private float currentYRotation;

    // Initial rotation for reference
    private Quaternion initialRotation;

    void Start()
    {
        // Save the initial rotation of the camera
        initialRotation = transform.rotation;

        // Initialize current rotation values with the initial rotation
        currentXRotation = initialRotation.eulerAngles.x;
        currentYRotation = initialRotation.eulerAngles.y;
    }

    void Update()
    {
        // Get mouse position as normalized values (percentage of screen width/height)
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;  // Normalize between -0.5 and 0.5
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f; // Normalize between -0.5 and 0.5

        // Calculate target rotation changes based on the mouse position
        float targetXRotation = -mouseY * rotationAmount;  // Rotate on X-axis (up/down)
        float targetYRotation = mouseX * rotationAmount;   // Rotate on Y-axis (left/right)

        // Apply rotation changes to the current rotation
        currentXRotation = Mathf.Lerp(currentXRotation, targetXRotation, smoothSpeed * Time.deltaTime);
        currentYRotation = Mathf.Lerp(currentYRotation, targetYRotation, smoothSpeed * Time.deltaTime);

        // Clamp the rotations within the specified limits
        currentXRotation = Mathf.Clamp(currentXRotation, rotationXLimit.x, rotationXLimit.y);
        currentYRotation = Mathf.Clamp(currentYRotation, rotationYLimit.x, rotationYLimit.y);

        // Construct the new camera rotation using quaternions
        Quaternion xQuaternion = Quaternion.AngleAxis(currentXRotation, Vector3.right);
        Quaternion yQuaternion = Quaternion.AngleAxis(currentYRotation, Vector3.up);

        // Apply the new rotation to the camera
        transform.localRotation = initialRotation * xQuaternion * yQuaternion;
    }
}
