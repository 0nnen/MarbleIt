using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Canvas Game Over
    [SerializeField] private string sceneToReload; // Le nom de la sc�ne � recharger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player a touch� le fond, affichage du Game Over Canvas...");
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
            Debug.LogError("Aucun Canvas Game Over assign� !");
        }
    }

    // M�thode pour red�marrer la sc�ne
    public void RestartScene()
    {
        // Assurez-vous que le temps est r�tabli avant de recharger la sc�ne
        Time.timeScale = 1f; // R�activer le temps
        SceneManager.LoadScene(sceneToReload); // Recharger la sc�ne
        Debug.Log("La sc�ne a �t� recharg�e.");
    }
}
