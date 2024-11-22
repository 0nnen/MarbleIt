using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour recharger la sc�ne

public class ResetOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre dans le trigger a le tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a touch� le fond, red�marrage de la partie...");
            ResetGame();
        }
    }

    private void ResetGame()
    {
        // Recharge la sc�ne active
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
