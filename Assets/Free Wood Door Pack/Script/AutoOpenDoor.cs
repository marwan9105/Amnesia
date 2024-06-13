using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    public bool open = false; // Par défaut, la porte est fermée
    public float smooth = 1.0f; // Augmenter cette valeur pour ouvrir la porte plus rapidement
    public float DoorOpenAngle = 90.0f; // Angle d'ouverture
    public float DoorCloseAngle = 0.0f; // Angle de fermeture
    public AudioSource asource;
    public AudioClip openDoor;

    void Start()
    {
        asource = GetComponent<AudioSource>();
        SetDoorState(open);
    }

    void Update()
    {
        if (open)
        {
            var target = Quaternion.Euler(0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !open) // Vérifie si la porte est fermée
        {
            OpenDoor(); // Ouvre la porte si elle est fermée
        }
    }

    public void OpenDoor()
    {
        open = true;
        asource.clip = openDoor;
        asource.Play();
    }

    private void SetDoorState(bool isOpen)
    {
        // Définir l'état initial de la porte
        var target = isOpen ? Quaternion.Euler(0, DoorOpenAngle, 0) : Quaternion.Euler(0, DoorCloseAngle, 0);
        transform.localRotation = target;
    }
}
