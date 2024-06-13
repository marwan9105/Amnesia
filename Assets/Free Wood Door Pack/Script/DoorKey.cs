using UnityEngine;

namespace DoorKeyScript
{
    [RequireComponent(typeof(AudioSource))]
    public class DoorKey : MonoBehaviour
    {
        public bool open;
        public float smooth = 1.0f;
        float DoorOpenAngle = -90.0f;
        float DoorCloseAngle = 0.0f;
        public AudioSource asource;
        public AudioClip openDoor, closeDoor;

        private KeyPickup keyPickup;

        void Start()
        {
            asource = GetComponent<AudioSource>();
            keyPickup = FindObjectOfType<KeyPickup>();
        }

        void Update()
        {
            // Vérifie si la clé a été ramassée et si la touche "E" est enfoncée pour ouvrir la porte
            if (keyPickup != null && KeyPickup.keyCollected && Input.GetKeyDown(KeyCode.E) && !open)
            {
                OpenDoor();
            }

            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
            }
        }

        public void OpenDoor()
        {
            open = true; // Assurez-vous que la porte ne se referme pas automatiquement
            asource.clip = openDoor;
            asource.Play();

            // Cacher l'image de la clé dans l'interface utilisateur
            if (keyPickup != null && keyPickup.keyImage != null)
            {
                keyPickup.keyImage.gameObject.SetActive(false);
            }
        }

        public void CloseDoor()
        {
            open = false; // Pour permettre de refermer la porte si nécessaire
            asource.clip = closeDoor;
            asource.Play();
        }
    }
}
