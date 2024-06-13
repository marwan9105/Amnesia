using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip backgroundMusic; // Assignez ici votre clip audio de fond
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Si l'AudioSource n'existe pas, ajoutez-en une
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configurez l'AudioSource
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Activer la lecture en boucle
        audioSource.playOnAwake = true; // Optionnel, pour démarrer la lecture dès le début du jeu
        audioSource.volume = 0.5f; // Ajustez le volume (1.0f est le volume maximal)

        // Jouez le son
        audioSource.Play();
    }
}
