using UnityEngine;

public class Score : MonoBehaviour
{
    private int coins = 0; // Nombre de pi�ces collect�es

    public void AddCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }
}
