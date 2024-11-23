using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; 

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

            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("Aucun Canvas Game Over assigné !");
        }
    }
}
