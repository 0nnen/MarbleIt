using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Score score; // R�f�rence au script Score

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c'est le joueur qui entre en collision
        {
            // Ajoute un coin
            if (score != null)
            {
                score.AddCoin();
            }
            else
            {
                Debug.LogWarning("R�f�rence au script Score manquante !");
            }

            // D�truit la pi�ce
            Destroy(gameObject);
        }
    }
}
