using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformEffectController : MonoBehaviour
{
    public enum PlatformEffectType
    {
        SpeedUp,
        SlowDown,
        ToggleGravity
    }

    [Header("Effect Settings")]
    [Tooltip("Type of effect this platform applies.")]
    public PlatformEffectType effectType;

    [Tooltip("Amount of speed/slow to add when in contact with this platform.")]
    [Range(0, 50)]
    public float speedSlowAmount = 10f;
}
