using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Canvas Game Over
    [SerializeField] private string sceneToReload; // Le nom de la scène à recharger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a touché le fond, affichage du Game Over Canvas...");
            ActivateGameOverCanvas();
        }
    }

    private void ActivateGameOverCanvas()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; // Mettre le jeu en pause
        }
        else
        {
            Debug.LogError("Aucun Canvas Game Over assigné !");
        }
    }

    // Méthode pour redémarrer la scène
    public void RestartScene()
    {
        // Assurez-vous que le temps est rétabli avant de recharger la scène
        Time.timeScale = 1f; // Réactiver le temps
        SceneManager.LoadScene(sceneToReload); // Recharger la scène
        Debug.Log("La scène a été rechargée.");
    }
}
