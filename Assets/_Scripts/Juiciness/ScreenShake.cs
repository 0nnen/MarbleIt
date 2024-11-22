using System.Collections;
using UnityEngine;

public class ScreenShakeEffect : MonoBehaviour
{
    public Camera mainCamera;
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.3f;

    private Vector3 originalPosition;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            originalPosition = mainCamera.transform.position;
            StartCoroutine(ShakeCamera());
        }
    }

    private IEnumerator ShakeCamera()
    {
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;
            mainCamera.transform.position = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = originalPosition;
    }
}
