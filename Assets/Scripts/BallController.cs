using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private float originalSpeed;
    private Coroutine speedChangeCoroutine;
    private bool isGravityReversed = false;
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
    }

    public void ApplySpeedChange(float multiplier, float duration)
    {
        if (speedChangeCoroutine != null)
        {
            StopCoroutine(speedChangeCoroutine);
        }

        speedChangeCoroutine = StartCoroutine(SpeedChangeRoutine(multiplier, duration));
    }

    private IEnumerator SpeedChangeRoutine(float multiplier, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Modifie la vitesse actuelle
            Vector3 currentVelocity = rb.velocity;
            rb.velocity = currentVelocity.normalized * originalSpeed * multiplier;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Transition fluide pour revenir à la vitesse normale
        float transitionTime = 1f; // Durée de la transition
        float transitionElapsed = 0f;

        while (transitionElapsed < transitionTime)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, rb.velocity.normalized * originalSpeed, transitionElapsed / transitionTime);
            transitionElapsed += Time.deltaTime;
            yield return null;
        }

        rb.velocity = rb.velocity.normalized * originalSpeed;
        speedChangeCoroutine = null;
    }

    public void ApplyGravityChange(float duration, bool isTemporary)
    {
        if (isGravityReversed)
        {
            Debug.LogWarning("Gravity reversal is already active. Ignoring this new effect.");
            return;
        }

        StartCoroutine(GravityChangeRoutine(duration, isTemporary));
    }

    private IEnumerator GravityChangeRoutine(float duration, bool isTemporary)
    {
        isGravityReversed = true;

        // Inverse la gravité
        rb.useGravity = false;
        rb.AddForce(Physics.gravity * -2, ForceMode.Acceleration);

        if (isTemporary)
        {
            yield return new WaitForSeconds(duration);

            // Transition fluide vers la gravité normale
            float elapsedTime = 0f;
            Vector3 targetGravity = Physics.gravity;

            while (elapsedTime < 1f)
            {
                rb.AddForce(Vector3.Lerp(rb.velocity, targetGravity, elapsedTime / 1f), ForceMode.Acceleration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rb.useGravity = true;
            isGravityReversed = false;
        }
    }

    public void ToggleGravity()
    {
        if (!isGravityToggled)
        {
            rb.useGravity = false;
            rb.AddForce(Physics.gravity * -2, ForceMode.Acceleration);
            isGravityToggled = true;
        }
        else
        {
            rb.useGravity = true;
            isGravityToggled = false;
        }
    }
}
