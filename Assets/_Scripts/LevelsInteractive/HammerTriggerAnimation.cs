using UnityEngine;

public class HammerTriggerAnimation : MonoBehaviour
{
    public Animator hammerAnimator; // R�f�rence � l�Animator du marteau
    public string hammerAnimationTrigger = "Swing"; // Nom du trigger dans l�Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c�est la bille qui entre dans la zone
        {
            PlayHammerAnimation();
        }
    }

    private void PlayHammerAnimation()
    {
        if (hammerAnimator != null)
        {
            hammerAnimator.SetTrigger(hammerAnimationTrigger); // Joue l�animation
        }
        else
        {
            Debug.LogWarning("Animator du marteau non assign� !");
        }
    }
}
