using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [Header("FX Settings")]
    [Tooltip("Prefab for the impact FX.")]
    public GameObject impactFXPrefab;

    [Tooltip("Scaling factor for the FX size based on impact force.")]
    [Range(0.01f, 5f)]
    public float fxScaleMultiplier = 0.5f;

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
        // Calculate the force of the impact
        float impactForce = collision.relativeVelocity.magnitude;

        // Trigger FX if the prefab is assigned
        if (impactFXPrefab != null)
        {
            TriggerImpactFX(collision.contacts[0].point, impactForce);
        }
    }

    private void TriggerImpactFX(Vector3 position, float impactForce)
    {
        // Instantiate the FX at the impact position
        GameObject fxInstance = Instantiate(impactFXPrefab, position, Quaternion.identity);

        // Scale the FX based on the impact force
        float scaledSize = Mathf.Clamp(impactForce * fxScaleMultiplier, 0.1f, 5f);
        fxInstance.transform.localScale = new Vector3(scaledSize, scaledSize, scaledSize);

        // Optionally, destroy the FX after a short duration
        Destroy(fxInstance, 2f);
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
