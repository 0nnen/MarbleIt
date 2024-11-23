using UnityEngine;

public class FunnelManager : MonoBehaviour
{
    CameraController camController;
    // Start is called before the first frame update
    void Awake()
    {
        camController = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter(Collider other){
        camController.SetEntonnoir(gameObject);
    }
    private void OnTriggerExit(Collider other){
        camController.SetEntonnoir(null);
    }
}
