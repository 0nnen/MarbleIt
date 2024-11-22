using UnityEngine;

public class DynamicCameraController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The ball that the camera will follow.")]
    public Transform ball;

    [Tooltip("The camera object to control.")]
    public Transform cameraTransform;

    [Header("Settings")]
    [Tooltip("Offset position of the camera relative to the ball.")]
    public Vector3 cameraOffset = new Vector3(0, 1, -3.5f);

    [Tooltip("Angle offset to make the camera look slightly above the ball.")]
    [Range(-45f, 45f)]
    public float verticalAngleOffset = 10f;

    [Tooltip("Speed of camera rotation smoothing.")]
    [Range(0.1f, 5f)]
    public float rotationSmoothing = 4.5f;

    [Tooltip("Speed of camera position smoothing.")]
    [Range(0.1f, 5f)]
    public float positionSmoothing = 4.5f;

    private Rigidbody ballRigidbody;

    private void Start()
    {
        if (ball == null || cameraTransform == null)
        {
            Debug.LogError("Ball or Camera Transform is not assigned in the DynamicCameraController script.");
            enabled = false;
            return;
        }

        ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody == null)
        {
            Debug.LogError("The assigned ball does not have a Rigidbody component.");
            enabled = false;
            return;
        }
    }

    private void LateUpdate()
    {
        if (ball == null || ballRigidbody == null || cameraTransform == null) return;

        // Calculate the direction based on the ball's velocity
        Vector3 velocityDirection = ballRigidbody.velocity.normalized;

        // Ignore the Y component of the velocity to keep the camera's Y rotation fixed
        velocityDirection.y = 0;

        // If the ball is stationary, maintain the current forward direction
        if (velocityDirection == Vector3.zero)
        {
            velocityDirection = cameraTransform.forward;
        }

        // Add the vertical angle offset
        Quaternion targetRotation = Quaternion.LookRotation(velocityDirection);
        targetRotation = Quaternion.Euler(verticalAngleOffset, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // Smoothly rotate the camera towards the target rotation
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRotation, Time.deltaTime * rotationSmoothing);

        // Smoothly update the camera position relative to the ball
        Vector3 targetPosition = ball.position + cameraTransform.rotation * cameraOffset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, Time.deltaTime * positionSmoothing);
    }
}
