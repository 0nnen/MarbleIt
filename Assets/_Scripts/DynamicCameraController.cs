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

    private GameObject entonnoir;

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
        if (cameraTransform == null) return;

        // Si un entonnoir est défini, positionner la caméra par rapport à lui
        if (entonnoir != null)
        {
            // Position cible directement au-dessus de l'entonnoir
            Vector3 targetPosition = entonnoir.transform.position + Vector3.up * cameraOffset.magnitude * 2;

            // Rotation pour regarder vers le bas
            Quaternion targetRotation = Quaternion.LookRotation(entonnoir.transform.position - targetPosition);

            // Interpoler la position et la rotation pour un mouvement fluide
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, Time.deltaTime * positionSmoothing);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRotation, Time.deltaTime * rotationSmoothing);

            return; // Sortir de la méthode, car le comportement pour la bille n'est pas nécessaire
        }

        // Comportement par défaut si entonnoir est null
        if (ball == null || ballRigidbody == null) return;

        // Calculer la direction en fonction de la vitesse de la bille
        Vector3 velocityDirection = ballRigidbody.velocity.normalized;

        // Ignorer la composante Y pour stabiliser la rotation verticale
        velocityDirection.y = 0;

        // Si la bille est immobile, conserver la direction actuelle
        if (velocityDirection == Vector3.zero)
        {
            velocityDirection = cameraTransform.forward;
        }

        // Ajouter l'offset vertical
        Quaternion targetRotationForBall = Quaternion.LookRotation(velocityDirection);
        targetRotationForBall = Quaternion.Euler(verticalAngleOffset, targetRotationForBall.eulerAngles.y, targetRotationForBall.eulerAngles.z);

        // Rotation fluide vers la direction cible
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRotationForBall, Time.deltaTime * rotationSmoothing);

        // Position cible relative à la bille
        Vector3 targetPositionForBall = ball.position + cameraTransform.rotation * cameraOffset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPositionForBall, Time.deltaTime * positionSmoothing);
    }

    public void SetEntonnoir(GameObject _entonnoir){
        entonnoir = _entonnoir;
    }
}
