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
    private float targetX; // Position horizontale cible

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed){return;}
        Vector2 screenPosition = context.ReadValue<Vector2>();

        // Convertir en coordonnées du monde
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.transform.position.y - transform.position.y));
        Debug.Log(worldPosition);
        // Mettre à jour la position cible uniquement sur l'axe X
        targetX = worldPosition.x;
        // Calculer la position actuelle et la cible
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(targetX, currentPosition.y, currentPosition.z);
        transform.position = targetPosition;
    }
}
