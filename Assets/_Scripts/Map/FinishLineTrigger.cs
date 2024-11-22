using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLineTrigger : MonoBehaviour
{

    private CameraController cameraController; // Référence au contrôleur de caméra
    public Canvas canvas;
    public GameObject confettiPrefab;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogError("CameraController non trouvé sur la caméra principale.");
        }
        // S'assurer que le canvas est désactivé au début
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Désactiver le contrôle du joueur
            other.GetComponent<PlayerController>().SetCanMove(false);

            // Activer la vue de la ligne d'arrivée
            if (cameraController != null)
            {
                cameraController.SetFinishLine(gameObject);
                Debug.Log("Vue de ligne d'arrivée activée.");
            }

            // Activer le canvas
            if (canvas != null)
            {
                canvas.gameObject.SetActive(true);
                Debug.Log("Canvas activé.");

                // Faire apparaître les confettis
                SpawnConfetti();
            }
        }
    }

    private void SpawnConfetti()
    {
        if (confettiPrefab != null && canvas != null)
        {
            // Obtenir la position du canvas pour placer les confettis
            RectTransform canvasTransform = canvas.GetComponent<RectTransform>();
            if (canvasTransform != null)
            {
                // Instancier les confettis au centre du canvas
                GameObject confettiInstance = Instantiate(confettiPrefab, canvasTransform.position, Quaternion.identity);
                confettiInstance.transform.SetParent(canvas.transform, false); // Assurer que les confettis restent dans le canvas
                Debug.Log("Confettis spawnés.");
            }
        }
        else
        {
            Debug.LogWarning("ConfettiPrefab ou Canvas non assigné.");
        }
    }
}
