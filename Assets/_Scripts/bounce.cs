using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public float bounceForce;
    [SerializeField] GameObject bille;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (bille != null)
        {
            bille.GetComponentInChildren<Rigidbody>().AddForce(0,bounceForce,0, ForceMode.Impulse);
        }
    }
}
