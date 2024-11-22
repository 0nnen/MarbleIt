using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    public Renderer objectRenderer;
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    private Color originalColor;
    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = objectRenderer.material;
        originalColor = objectMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        objectMaterial.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        objectMaterial.color = originalColor;
    }
}
