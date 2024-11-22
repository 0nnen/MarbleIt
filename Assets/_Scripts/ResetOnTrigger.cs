using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour recharger la scène

public class ResetOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans le trigger a le tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a touché le fond, redémarrage de la partie...");
            ResetGame();
        }
    }

    private void ResetGame()
    {
        // Recharge la scène active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
