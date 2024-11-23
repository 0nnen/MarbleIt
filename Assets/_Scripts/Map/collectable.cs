using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Score score; // R�f�rence au script Score
    [SerializeField] private DisplayCoin displayCoin; // R�f�rence au script DisplayCoin

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c'est le joueur qui collecte l'objet
        {

             // Incr�mente le score
             displayCoin.AddCoin();

             // Met � jour l'interface utilisateur
             if (displayCoin != null)
             {
                 displayCoin.UpdateCoinText();
             }

             gameObject.GetComponent<AudioSource>().Play();
            // D�truit l'objet collectable
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        
    }
}
