using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{

    private CameraController cameraController; // R�f�rence au contr�leur de cam�ra
    public Canvas canvas;
    public GameObject confettiPrefab;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogError("CameraController non trouv� sur la cam�ra principale.");
        }
        // S'assurer que le canvas est d�sactiv� au d�but
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
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

            // Activer le canvas
            if (canvas != null)
            {
                canvas.gameObject.SetActive(true);
                Debug.Log("Canvas activ�.");

                // Faire appara�tre les confettis
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
                Debug.Log("Confettis spawn�s.");
            }
        }
        else
        {
            Debug.LogWarning("ConfettiPrefab ou Canvas non assign�.");
        }
    }
}
