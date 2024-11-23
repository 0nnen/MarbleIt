using UnityEngine;

public class timer : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
    }
    public float getTime()
    {
        return time;
    }
    public void resetTime()
    {
        time = 0;
    }
}
