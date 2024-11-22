using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelManager : MonoBehaviour
{
    DynamicCameraController camController;
    // Start is called before the first frame update
    void Awake()
    {
        camController = Camera.main.GetComponent<DynamicCameraController>();
    }

    private void OnTriggerEnter(Collider other){
        camController.SetEntonnoir(gameObject);
    }
    private void OnTriggerExit(Collider other){
        camController.SetEntonnoir(null);
    }
}
