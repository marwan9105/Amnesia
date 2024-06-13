using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    // Référence à l'objet clé
    public GameObject keyObject;

    // Référence à l'image de la clé dans l'interface utilisateur
    public Image keyImage;

    // Variable statique pour vérifier si la clé a été ramassée
    public static bool keyCollected = false;

    void Start()
    {
        // Cache l'image de la clé au début
        if (keyImage != null)
        {
            keyImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("keyImage n'est pas assigné dans l'inspecteur");
        }
    }

    // Fonction appelée lorsque le joueur clique sur la clé
    void OnMouseDown()
    {
        CheckForKey();
    }

    // Fonction appelée pour vérifier si la clé peut être ramassée
    void CheckForKey()
    {
        // Vérifie si le joueur regarde la clé
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == keyObject)
            {
                // Faire disparaître la clé
                keyObject.SetActive(false);
                Debug.Log("Clé ramassée !");
                
                // Afficher l'image de la clé dans l'interface utilisateur
                if (keyImage != null)
                {
                    keyImage.gameObject.SetActive(true);
                }

                // Mettre à jour la variable statique
                keyCollected = true;

                // Ajoutez ici le code pour ramasser la clé et effectuer d'autres actions nécessaires
            }
        }
    }
}
