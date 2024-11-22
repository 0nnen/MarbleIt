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

    private void OnCollisionEnter(Collision collision)
    {
        PlatformEffectController platformEffect = collision.gameObject.GetComponent<PlatformEffectController>();
        if (platformEffect != null)
        {
            switch (platformEffect.effectType)
            {
                case PlatformEffectController.PlatformEffectType.SpeedUp:
                    ApplySpeedIncrease(platformEffect.speedSlowAmount);
                    break;

                case PlatformEffectController.PlatformEffectType.SlowDown:
                    ApplySpeedReduction(platformEffect.speedSlowAmount);
                    break;

                case PlatformEffectController.PlatformEffectType.ToggleGravity:
                    ToggleGravity();
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
        float newSpeed = Mathf.Max(0, originalSpeed - amount); // Emp�che une vitesse n�gative
        rb.velocity = currentVelocity.normalized * newSpeed;
    }

    private void ResetSpeedToOriginal()
    {
        Vector3 currentVelocity = rb.velocity;
        rb.velocity = currentVelocity.normalized * originalSpeed;
    }

    private void ToggleGravity()
    {
        // Inverse la gravit� entre son �tat actuel et l'�tat original
        if (isGravityToggled)
        {
            Physics.gravity = originalGravity;
        }
        else
        {
            Physics.gravity = -originalGravity;
        }

        isGravityToggled = !isGravityToggled; // Bascule l'�tat de gravit�
    }
}