using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openSpeed = 2f; // La vitesse d'ouverture de la porte (ajustée pour une animation visible)
    private bool isPlayerNear = false; // Si le joueur est à proximité de la porte
    private Animator animator; // Référence à l'Animator

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No Animator component found on this object. Please add an Animator.");
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the "Open" parameter to trigger the animation
            bool isOpening = animator.GetBool("Open");
            animator.SetBool("Open", !isOpening);
            Debug.Log("Player pressed E. isOpening: " + !isOpening);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered trigger area. isPlayerNear: " + isPlayerNear);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player exited trigger area. isPlayerNear: " + isPlayerNear);
        }
    }
}
