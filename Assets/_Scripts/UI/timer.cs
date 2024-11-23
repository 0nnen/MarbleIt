using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;

    void Start()
    {
        time = 0;
    }

  
    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }

    public void ResetTime()
    {
        time = 0;
    }
}
