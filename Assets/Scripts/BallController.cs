using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private float originalSpeed;
    private bool isSpeedModified = false;
    private bool isGravityReversed = false;

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
    }

    public void ApplySpeedChange(float multiplier, float duration)
    {
        if (isSpeedModified)
        {
            Debug.LogWarning("Speed modification is already active. Ignoring this new effect.");
            return;
        }

        StartCoroutine(SpeedChangeRoutine(multiplier, duration));
    }

    private IEnumerator SpeedChangeRoutine(float multiplier, float duration)
    {
        isSpeedModified = true;

        // Adjust speed
        Vector3 velocity = rb.velocity;
        rb.velocity = velocity * multiplier;

        // Wait for the effect to expire
        yield return new WaitForSeconds(duration);

        // Revert to the original speed
        rb.velocity = rb.velocity.normalized * originalSpeed;
        isSpeedModified = false;
    }

    public void ApplyGravityChange(float duration)
    {
        if (isGravityReversed)
        {
            Debug.LogWarning("Gravity reversal is already active. Ignoring this new effect.");
            return;
        }

        StartCoroutine(GravityChangeRoutine(duration));
    }

    private IEnumerator GravityChangeRoutine(float duration)
    {
        isGravityReversed = true;

        // Reverse gravity
        rb.useGravity = false;
        rb.AddForce(Physics.gravity * -100, ForceMode.Acceleration);

        // Wait for the effect to expire
        yield return new WaitForSeconds(duration);

        // Restore original gravity
        rb.useGravity = true;
        isGravityReversed = false;
    }
}
