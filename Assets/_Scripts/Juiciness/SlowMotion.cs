using System.Collections;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour
{
    public float slowDownFactor = 0.5f;
    public float duration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SlowMotion());
        }
    }

    private IEnumerator SlowMotion()
    {
        Time.timeScale = slowDownFactor;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}
