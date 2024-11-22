using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformEffectController : MonoBehaviour
{
    public enum PlatformEffectType
    {
        SpeedUp,
        SlowDown,
        ToggleGravity,
        BounceUp
    }

    [Header("Effect Settings")]
    [Tooltip("Type of effect this platform applies.")]
    public PlatformEffectType effectType;

    [Tooltip("Amount of speed/slow to add when in contact with this platform.")]
    [Range(0, 50)]
    public float Amount = 10f;

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
}
