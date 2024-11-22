using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBounceEffect : MonoBehaviour
{
    public Vector3 bounceScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 0.2f;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BounceEffect());
        }
    }

    private IEnumerator BounceEffect()
    {
        transform.localScale = bounceScale;
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
    }
}
