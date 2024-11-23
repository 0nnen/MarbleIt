using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Score score; // Référence au script Score
    [SerializeField] private DisplayCoin displayCoin; // Référence au script DisplayCoin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur qui entre en collision
        {
            // Ajoute un coin et met à jour l'interface utilisateur
            score.AddCoin();
            displayCoin.UpdateCoinText();

            // Détruit la pièce
            Destroy(gameObject);
        }
    }
}
