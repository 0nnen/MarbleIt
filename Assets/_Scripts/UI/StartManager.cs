using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float forceMultiplyer = 300f;
    [SerializeField] private AudioSource backgroundMusic; 
    private bool canInput = true;

    private void Start()
    {
        // Lance la musique au début de la scène
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && canInput)
        {
            Debug.Log("Salam les patissier");
            Vector2 delta = context.ReadValue<Vector2>();

            if (delta.sqrMagnitude < 0.01f) return;

            anim.SetTrigger("Start");
            canInput = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController movementController = other.gameObject.GetComponent<PlayerController>();
            movementController.SetKinematic(false);
            movementController.ApplyForce(-Vector3.forward * forceMultiplyer);
        }
    }

    public void RestartLevel()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // Arrête la musique avant de redémarrer la scène
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
