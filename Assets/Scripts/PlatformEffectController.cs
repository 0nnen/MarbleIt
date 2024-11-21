using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformEffectController : MonoBehaviour
{
    public enum PlatformEffectType
    {
        SpeedUp,
        SlowDown,
        ReverseGravity,
        ToggleGravity
    }

    [Header("Platform Effect Settings")]
    public PlatformEffectType effectType;

    [Tooltip("Multiplier for speed change. Not used for gravity effects.")]
    [Range(0.1f, 15.0f)]
    public float speedMultiplier = 1.0f;

    [Tooltip("Duration in seconds for how long the effect lasts. Ignored for ToggleGravity.")]
    public float effectDuration = 2.0f;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (!collider.isTrigger)
        {
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
                        ballController.ApplyGravityChange(effectDuration, true);
                        break;

                    case PlatformEffectType.ToggleGravity:
                        ballController.ToggleGravity();
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
