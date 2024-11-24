using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Score score; // Référence au script Score

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur qui entre en collision
        {
            // Ajoute un coin
            if (score != null)
            {
                score.AddCoin();
            }
            else
            {
                Debug.LogWarning("Référence au script Score manquante !");
            }

            // Détruit la pièce
            Destroy(gameObject);
        }
    }
}
