using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarbleMovementController : MonoBehaviour
{   
    public float moveSpeed = 5f; // Vitesse d'ajustement de la bille
    private Rigidbody rb;
    private Camera mainCamera;
    private Vector3 targetPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed){return;}
        Vector2 screenPosition = context.ReadValue<Vector2>();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y,10f));
        targetPosition = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
    }

    void FixedUpdate(){
        Vector3 direction = (targetPosition - transform.position).normalized;
        if(Mathf.Abs(transform.position.x - targetPosition.x) > 0.1f && targetPosition != Vector3.zero){
            rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, rb.velocity.z);
        }else if(Mathf.Abs(transform.position.x - targetPosition.x) <= 0.1f && targetPosition != Vector3.zero){
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            targetPosition = Vector3.zero;
        }
    }
}
