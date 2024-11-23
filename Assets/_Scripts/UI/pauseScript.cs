using UnityEngine;

public class pauseScript : MonoBehaviour
{
    [SerializeField] GameObject Playing;
    [SerializeField] GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        Playing.SetActive(false);
        Pause.SetActive(true);
        
        Time.timeScale = 0;
    }
    public void resume()
    {
        Playing.SetActive(true);
        Pause.SetActive(false);
        
        Time.timeScale = 1;
    }
}
