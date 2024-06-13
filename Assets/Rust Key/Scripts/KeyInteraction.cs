using UnityEngine;
using UnityEngine.UI;

public class KeyInteraction : MonoBehaviour
{
    public KeyUIManager keyUIManager; // Assignez ce script dans l'inspecteur
    public Camera playerCamera; // Assignez la caméra du joueur dans l'inspecteur

    void Update()
    {
        // Vérifie si le joueur a cliqué avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Crée un raycast depuis la caméra vers la position de la souris
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Vérifie si le raycast a touché quelque chose
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifie si l'objet touché est une clé
                if (hit.collider.CompareTag("Key"))
                {
                    // Appelle la méthode pour afficher la clé dans l'UI
                    keyUIManager.ShowKey();
                    // Détruit la clé dans la scène
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
