using TMPro;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    private int coins = 0; // Compteur local des pi�ces
    [SerializeField] private TextMeshProUGUI coinText; // Texte UI pour afficher les pi�ces

    private void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("R�f�rence � TextMeshProUGUI manquante !");
            return;
        }

        // Initialisation du texte
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++; // Incr�mente les pi�ces locales
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
            Debug.Log($"Mise � jour du texte : {coins}");
        }
    }
}
