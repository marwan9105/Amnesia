using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Image letterImage; // Référence à l'image de la lettre à afficher
    public GameObject interactionText; // Référence au texte d'interaction
    private bool isImageVisible = false; // Variable pour suivre l'état d'affichage de l'image

    void Start()
    {
        if (letterImage != null)
        {
            letterImage.gameObject.SetActive(false); // Désactiver l'image au démarrage si ce n'est pas déjà fait
        }
        else
        {
            Debug.LogWarning("L'image de la lettre n'est pas assignée dans l'inspecteur.");
        }

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false); // Désactiver le texte d'interaction au démarrage
        }
        else
        {
            Debug.LogWarning("Le texte d'interaction n'est pas assigné dans l'inspecteur.");
        }
    }

    void Update()
    {
        // Vérifier si le joueur est à portée de la lettre
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.gameObject == gameObject) // Vérifie si le rayon touche l'objet de la lettre
            {
                Debug.Log("Player is looking at the letter.");
                // Activer le texte d'interaction
                interactionText.gameObject.SetActive(true);

                // Vérifier si le joueur appuie sur la touche E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E key is pressed.");
                    // Inverser l'état de visibilité de l'image
                    if (!isImageVisible)
                    {
                        ShowLetterImage();
                    }
                    else
                    {
                        HideLetterImage();
                    }
                }
            }
            else
            {
                Debug.Log("Player is not looking at the letter.");
                // Désactiver le texte d'interaction si le joueur n'est pas à portée de la lettre
                interactionText.gameObject.SetActive(false);
            }
        }
    }


    void ShowLetterImage()
    {
        if (letterImage != null)
        {
            letterImage.gameObject.SetActive(true); // Activer l'image de la lettre
            isImageVisible = true; // Mettre à jour l'état d'affichage
        }
    }

    void HideLetterImage()
    {
        if (letterImage != null)
        {
            letterImage.gameObject.SetActive(false); // Désactiver l'image de la lettre
            isImageVisible = false; // Mettre à jour l'état d'affichage
        }
    }
}
