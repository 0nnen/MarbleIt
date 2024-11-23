using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Score score; // Référence au script Score
    [SerializeField] private DisplayCoin displayCoin; // Référence au script DisplayCoin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur qui collecte l'objet
        {

             // Incrémente le score
             displayCoin.AddCoin();

             // Met à jour l'interface utilisateur
             if (displayCoin != null)
             {
                 displayCoin.UpdateCoinText();
             }

             // Détruit l'objet collectable
             Destroy(gameObject);
        }
    }
}
