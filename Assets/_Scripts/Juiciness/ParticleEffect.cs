using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public ParticleSystem particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && particleEffect != null)
        {
            particleEffect.Play(); // Joue les particules
        }
    }
}

