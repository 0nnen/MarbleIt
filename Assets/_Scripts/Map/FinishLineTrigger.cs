using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLineTrigger : MonoBehaviour
{

    private CameraController cameraController; // R�f�rence au contr�leur de cam�ra

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogError("CameraController non trouv� sur la cam�ra principale.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // D�sactiver le contr�le du joueur
            other.GetComponent<PlayerController>().SetCanMove(false);

            // Activer la vue de la ligne d'arriv�e
            if (cameraController != null)
            {
                cameraController.SetFinishLine(gameObject);
                Debug.Log("Vue de ligne d'arriv�e activ�e.");
            }
        }
    }
}
