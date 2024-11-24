using UnityEngine;

public class Score : MonoBehaviour
{
    private int coins = 0; // Nombre de pièces collectées

    public void AddCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }
}
