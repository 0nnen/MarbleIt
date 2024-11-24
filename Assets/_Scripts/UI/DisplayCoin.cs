using TMPro;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    private int coins = 0; // Compteur local des pièces
    [SerializeField] private TextMeshProUGUI coinText; // Texte UI pour afficher les pièces

    private void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("Référence à TextMeshProUGUI manquante !");
            return;
        }

        // Initialisation du texte
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++; // Incrémente les pièces locales
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
            Debug.Log($"Mise à jour du texte : {coins}");
        }
    }
}
