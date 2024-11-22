using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLineTrigger : MonoBehaviour
{

    private CameraController cameraController; // Référence au contrôleur de caméra

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogError("CameraController non trouvé sur la caméra principale.");
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
        }
    }
}
