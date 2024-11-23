using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] timer timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = timer.getTime().ToString("F1");
    }
}
