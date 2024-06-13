using UnityEngine;

public class LookAtRingTrigger : MonoBehaviour
{
    public AudioClip dialogueAudio; // Audio du dialogue à jouer
    private AudioSource audioSource;
    private bool hasPlayed = false;

    // Distance maximale pour détecter l'objet
    public float maxDistance = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasPlayed && IsPlayerLookingAtRing())
        {
            PlayDialogue();
        }
    }

    bool IsPlayerLookingAtRing()
    {
        // Raycast from the camera to detect if looking at the ring
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider == GetComponent<Collider>())
            {
                return true;
            }
        }

        return false;
    }

    void PlayDialogue()
    {
        if (dialogueAudio != null && audioSource != null)
        {
            audioSource.clip = dialogueAudio;
            audioSource.Play();
            hasPlayed = true;
        }
        else
        {
            Debug.LogWarning("Dialogue audio or AudioSource is not assigned!");
        }
    }
}
