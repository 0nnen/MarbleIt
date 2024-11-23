using TMPro;
using UnityEngine;

public class DisplayCoin : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Score score; // Référence au script Score
    [SerializeField] private TextMeshProUGUI coinText; // Référence au texte UI

    private void Start()
    {
        if (score == null || coinText == null)
        {
            Debug.LogError("Score or TextMeshProUGUI reference is missing!");
            return;
        }

        // Initialiser l'affichage avec le score actuel
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        // Met à jour le texte UI avec le score actuel
        coinText.text = coins.ToString();
    }

    public void AddCoin()
    {
        coins++;
    }

}
