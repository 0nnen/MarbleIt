using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float forceMultiplyer = 300f;
    bool canInput = true;


    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        if (context.phase == InputActionPhase.Performed && canInput)
        {
            Debug.Log("Salam les patissier");
            Vector2 delta = context.ReadValue<Vector2>();

            if (delta.y <= 0)

            if (delta.sqrMagnitude < 0.01f) return;

            anim.SetTrigger("Start");   

            canInput = false;

            Debug.Log("Bougnoul");
        }
            
    }

    async void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            PlayerController movementController = other.gameObject.GetComponent<PlayerController>();
            movementController.SetKinematic(false);
            await Task.Delay(10);
            movementController.ApplyForce(-Vector3.forward * forceMultiplyer );    
        }
    }
}
