using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight; // Assigner la lumière de type spot ici
    public KeyCode toggleKey = KeyCode.G; // La touche pour allumer/éteindre la lampe torche
    public bool isOn = false; // L'état actuel de la lampe torche
    public AudioSource asource;
    public AudioClip SwitchOn, SwitchOff;

    void Start () {
        asource = GetComponent<AudioSource>();
        flashlight.enabled = isOn; // Assurez-vous que la lampe torche est dans l'état correct au démarrage
    }

    void Update()
    {
        // Vérifier si la touche spécifiée est pressée
        if (Input.GetKeyDown(toggleKey))
        {
            // Basculer l'état de la lampe torche
            isOn = !isOn;
            flashlight.enabled = isOn;

            // Jouer le son approprié
            if (isOn)
            {
                asource.clip = SwitchOn;
            }
            else
            {
                asource.clip = SwitchOff;
            }
            asource.Play();
        }
    }
}
