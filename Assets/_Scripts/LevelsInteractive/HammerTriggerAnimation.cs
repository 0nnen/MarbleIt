using UnityEngine;

public class HammerTriggerAnimation : MonoBehaviour
{
    public Animator hammerAnimator; // Référence à l’Animator du marteau
    public string hammerAnimationTrigger = "Swing"; // Nom du trigger dans l’Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c’est la bille qui entre dans la zone
        {
            PlayHammerAnimation();
        }
    }

    private void PlayHammerAnimation()
    {
        if (hammerAnimator != null)
        {
            hammerAnimator.SetTrigger(hammerAnimationTrigger); // Joue l’animation
        }
        else
        {
            Debug.LogWarning("Animator du marteau non assigné !");
        }
    }
}
