using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private float originalSpeed;
    private Vector3 originalGravity;
    private bool isGravityToggled = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on the Player object!");
        }
    }

    private void Start()
    {
        originalSpeed = rb.velocity.magnitude;
        originalGravity = Physics.gravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlatformEffectController platformEffect = other.gameObject.GetComponent<PlatformEffectController>();

        if (platformEffect != null)
        {
            switch (platformEffect.effectType)
            {
                case PlatformEffectController.PlatformEffectType.SpeedUp:
                    ApplySpeedIncrease(platformEffect.Amount);
                    break;

                case PlatformEffectController.PlatformEffectType.SlowDown:
                    ApplySpeedReduction(platformEffect.Amount);
                    break;

                case PlatformEffectController.PlatformEffectType.ToggleGravity:
                    ToggleGravity();
                    break;
                case PlatformEffectController.PlatformEffectType.BounceUp:
                    BounceUp(platformEffect.Amount);
                    break;
            }
        }
    }

    private void ApplySpeedIncrease(float amount)
    {
        Vector3 currentVelocity = rb.velocity;
        rb.velocity = currentVelocity.normalized * (originalSpeed + amount);
    }

    private void ApplySpeedReduction(float amount)
    {
        Vector3 currentVelocity = rb.velocity;
        float newSpeed = Mathf.Max(0, originalSpeed - amount); // Empêche une vitesse négative
        rb.velocity = currentVelocity.normalized * newSpeed;
    }

    private void ResetSpeedToOriginal()
    {
        Vector3 currentVelocity = rb.velocity;
        rb.velocity = currentVelocity.normalized * originalSpeed;
    }

    private void ToggleGravity()
    {
        // Inverse la gravité entre son état actuel et l'état original
        if (isGravityToggled)
        {
            Physics.gravity = originalGravity;
        }
        else
        {
            Physics.gravity = -originalGravity;
        }

        isGravityToggled = !isGravityToggled; // Bascule l'état de gravité
    }

   private void BounceUp(float amount)
    {
        rb.AddForce(Vector3.up * amount, ForceMode.Impulse);
    }
}
