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
    Vector3 lastDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
            if (context.phase == InputActionPhase.Performed)
            {
                // Lire le delta directement depuis le context (mouvement relatif de l'input)
                Vector2 delta = context.ReadValue<Vector2>();

                // Si le delta est nul ou trop faible, on ne fait rien
                if (delta.sqrMagnitude < 0.01f) return;

                // Normaliser le delta pour obtenir uniquement la direction
                delta.Normalize();

                // Convertir le delta dans l'espace de la caméra
                Vector3 screenToWorldDelta = mainCamera.transform.TransformDirection(new Vector3(delta.x, 0f, delta.y));
                
                // Stocker la direction comme la direction dans laquelle appliquer la force
                lastDirection = screenToWorldDelta.normalized;

                // Appliquer la force dans la direction calculée
                rb.AddForce(lastDirection * 1f, ForceMode.Impulse);
            }
            
    }

    public void SetKinematic(bool _kinematic){
        rb.isKinematic = _kinematic;
    }

    public void ApplyForce(Vector3 _vector){
        rb.AddForce(_vector);
    }
}

    // void FixedUpdate(){
    //     Vector3 direction = (targetPosition - transform.position).normalized;
    //     if(Mathf.Abs(transform.position.x - targetPosition.x) > 0.1f && targetPosition != Vector3.zero){
    //         rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, rb.velocity.z);
    //     }else if(Mathf.Abs(transform.position.x - targetPosition.x) <= 0.1f && targetPosition != Vector3.zero){
    //         rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
    //         targetPosition = Vector3.zero;
    //     }
    // }

