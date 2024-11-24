using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private DisplayCoin displayCoin; // Référence au script DisplayCoin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si le joueur entre en collision
        {
            if (displayCoin != null)
            {
                displayCoin.AddCoin(); // Ajoute une pièce et met à jour l'UI
            }
            else
            {
                Debug.LogWarning("Référence à DisplayCoin manquante !");
            }

            // Lecture du son (si disponible)
            if (gameObject.TryGetComponent<AudioSource>(out AudioSource audioSource))
            {
                audioSource.Play();
            }

            // Désactive le collectable et le détruit
            if (gameObject.TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
            {
                renderer.enabled = false;
            }

            Destroy(gameObject, 0.5f); // Délai pour permettre au son de se jouer
        }
    }
}
