using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getCoins()
    {
        return coins;
    }
    public void setCoins()
    {
        coins++;
        Debug.Log("Coins: " + coins);
    }
}
