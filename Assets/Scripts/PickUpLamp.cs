using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLamp : MonoBehaviour
{
    public float pickupDistance = 3f; // Distance à laquelle le joueur peut ramasser la lampe
    public GameObject interactionText; // Référence au texte d'interaction
    public GameObject lamp; // Référence à la lampe à ramasser
    public GameObject secondLamp; // Référence à la deuxième lampe qui doit apparaître

    void Start()
    {
        secondLamp.SetActive(false); // Assurez-vous que la deuxième lampe est désactivée au démarrage
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
        {
            if (hit.transform == lamp.transform) // Vérifie si la lampe est dans la ligne de mire du joueur
            {
                interactionText.SetActive(true); // Active le texte d'interaction
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Ramasser la lampe
                    lamp.SetActive(false); // Désactive la lampe ramassée
                    secondLamp.SetActive(true); // Active la deuxième lampe
                }
            }
            else
            {
                interactionText.SetActive(false); // Désactive le texte d'interaction s'il n'y a pas de lampe dans la ligne de mire
            }
        }
        else
        {
            interactionText.SetActive(false); // Désactive le texte d'interaction s'il n'y a pas d'objet à ramasser dans la ligne de mire
        }
    }
}
