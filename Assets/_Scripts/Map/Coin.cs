using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Score score; // R�f�rence au script Score
    [SerializeField] private DisplayCoin displayCoin; // R�f�rence au script DisplayCoin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c'est le joueur qui entre en collision
        {
            // Ajoute un coin et met � jour l'interface utilisateur
            score.AddCoin();
            displayCoin.UpdateCoinText();

            // D�truit la pi�ce
            Destroy(gameObject);
        }
    }
}
