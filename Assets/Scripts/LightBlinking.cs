using System.Collections;
using UnityEngine;

public class LightBlinking : MonoBehaviour
{
    public Light flashlight; // Assigner la lumière de type spot ici
    public bool isOn = false; // L'état actuel de la lampe torche
    public AudioSource asource;
    public AudioClip flickerSound; // Son de clignotement de l'ampoule défectueuse
    public GameObject interactionText; // Référence au texte d'interaction
    public float pickupDistance = 3f; // Distance à laquelle le joueur peut ramasser la lampe
    public GameObject secondLamp; // Référence à la deuxième lampe

    void Start()
    {
        asource = GetComponent<AudioSource>();
        asource.clip = flickerSound;
        asource.loop = true; // Faire en sorte que le son se répète en boucle
        asource.Play(); // Démarrer la lecture du son
        flashlight.enabled = isOn; // Assurez-vous que la lampe torche est dans l'état correct au démarrage
        StartCoroutine(BlinkingLight()); // Démarre la coroutine pour le clignotement

        // Assurez-vous que la deuxième lampe est désactivée au départ
        if (secondLamp != null)
        {
            secondLamp.SetActive(false);
        }

        // Affichez la position de la lampe au démarrage
        Debug.Log("Lampe position: " + transform.position);
    }

    IEnumerator BlinkingLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f); // Attendre 0.2 seconde
            ToggleFlashlight();
        }
    }

    void Update()
    {
        CheckForPickup();
    }

    void CheckForPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupDistance))
        {
            if (hit.transform == transform) // Vérifie si la lampe est dans la ligne de mire du joueur
            {
                interactionText.SetActive(true); // Active le texte d'interaction
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Lampe ramassée.");
                    gameObject.SetActive(false); // Désactive la lampe

                    // Active la deuxième lampe
                    if (secondLamp != null)
                    {
                        secondLamp.SetActive(true);
                    }
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

    void ToggleFlashlight()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
    }
}
