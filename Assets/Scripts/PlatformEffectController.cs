using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformEffectController : MonoBehaviour
{
    public enum PlatformEffectType
    {
        SpeedUp,
        SlowDown,
        ReverseGravity
    }

    [Header("Platform Effect Settings")]
    [Tooltip("Choose the effect type: SpeedUp, SlowDown, or ReverseGravity.")]
    public PlatformEffectType effectType;

    [Tooltip("Multiplier for speed change. Not used for ReverseGravity.")]
    [Range(0.1f, 3.0f)]
    public float speedMultiplier = 1.0f;

    [Tooltip("Duration in seconds for how long the effect lasts.")]
    public float effectDuration = 2.0f;

    private void Start()
    {
        // Ensure the collider is set to trigger
        Collider collider = GetComponent<Collider>();
        if (!collider.isTrigger)
        {
            Debug.LogWarning($"The collider on {gameObject.name} is not set to 'Is Trigger'. Automatically fixing this.");
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BallController ballController = other.GetComponent<BallController>();
            if (ballController != null)
            {
                switch (effectType)
                {
                    case PlatformEffectType.SpeedUp:
                        ballController.ApplySpeedChange(speedMultiplier, effectDuration);
                        break;

                    case PlatformEffectType.SlowDown:
                        ballController.ApplySpeedChange(1.0f / speedMultiplier, effectDuration);
                        break;

                    case PlatformEffectType.ReverseGravity:
                        ballController.ApplyGravityChange(effectDuration);
                        break;

                    default:
                        Debug.LogWarning("Unsupported effect type!");
                        break;
                }
            }
            else
            {
                Debug.LogError($"The object {other.name} does not have a BallController script attached!");
            }
        }
    }
}
