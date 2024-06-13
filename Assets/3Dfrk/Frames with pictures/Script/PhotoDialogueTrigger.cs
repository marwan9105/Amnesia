using UnityEngine;
using UnityEngine.UI; // N'oubliez pas d'ajouter cette ligne pour utiliser l'UI

public class PhotoDialogueTrigger : MonoBehaviour
{
    public AudioClip dialogueAudio; 
    private AudioSource audioSource;
    private bool hasPlayed = false;

    public Image fearBar; // Référence à l'image de la barre de peur
    public float fearDecreaseAmount = 60f; // Quantité de peur à diminuer

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    void Update()
    {
        if (!hasPlayed && IsPlayerLookingAtPhoto())
        {
            PlayDialogue();
            DecreaseFear();
        }
    }

    bool IsPlayerLookingAtPhoto()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit))
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
            Debug.Log("Dialogue audio played!"); // Ajoute un message de débogage pour vérifier si le dialogue audio est joué
        }
        else
        {
            Debug.LogWarning("Dialogue audio or AudioSource is not assigned!"); // Ajoute un avertissement si le dialogue audio ou l'AudioSource ne sont pas configurés correctement
        }
    }

    private void DecreaseFear()
    {
        if (fearBar != null)
        {
            // Diminuer la largeur de la barre de peur
            RectTransform rt = fearBar.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(Mathf.Max(0, rt.sizeDelta.x - fearDecreaseAmount), rt.sizeDelta.y);
        }
        else
        {
            Debug.LogWarning("Fear bar Image is not assigned.");
        }
    }
}
