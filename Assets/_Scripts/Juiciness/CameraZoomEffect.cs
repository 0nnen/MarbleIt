using System.Collections;
using UnityEngine;

public class CameraZoomEffect : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomAmount = 20f;
    public float duration = 0.5f;

    private float originalFOV;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        originalFOV = mainCamera.fieldOfView;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ZoomEffect());
        }
    }

    private IEnumerator ZoomEffect()
    {
        mainCamera.fieldOfView = zoomAmount;
        yield return new WaitForSeconds(duration);
        mainCamera.fieldOfView = originalFOV;
    }
}

