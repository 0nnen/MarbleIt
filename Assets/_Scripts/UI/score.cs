using UnityEngine;

public class Score : MonoBehaviour
{
    private int coins = 0;


    // Incr�mente le score
    public void AddCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }
}
