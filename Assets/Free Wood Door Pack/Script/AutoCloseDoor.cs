using UnityEngine;
using UnityEngine.UI;

public class AutoCloseDoor : MonoBehaviour
{
    public bool open = true; // Par défaut, la porte est ouverte
    public float smooth = 5.0f; // Augmenter cette valeur pour fermer la porte plus rapidement
    public float DoorOpenAngle = 90.0f; // Angle d'ouverture
    public float DoorCloseAngle = 0.0f; // Angle de fermeture
    public AudioSource asource;
    public AudioClip closeDoor;

    public Image fearBar; // Référence à l'image de la barre de peur
    public float fearIncreaseAmount = 60f; // Quantité de peur à ajouter

    void Start()
    {
        asource = GetComponent<AudioSource>();
        SetDoorState(open);
    }

    void Update()
    {
        if (!open)
        {
            var target = Quaternion.Euler(0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && open)
        {
            CloseDoor();
            IncreaseFear();
        }
    }

    public void CloseDoor()
    {
        open = false;
        asource.clip = closeDoor;
        asource.Play();
    }

    private void SetDoorState(bool isOpen)
    {
        // Définir l'état initial de la porte
        var target = isOpen ? Quaternion.Euler(0, DoorOpenAngle, 0) : Quaternion.Euler(0, DoorCloseAngle, 0);
        transform.localRotation = target;
    }

    private void IncreaseFear()
    {
        if (fearBar != null)
        {
            // Augmenter la largeur de la barre de peur
            RectTransform rt = fearBar.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x + fearIncreaseAmount, rt.sizeDelta.y);
        }
        else
        {
            Debug.LogWarning("Fear bar Image is not assigned.");
        }
    }
}
