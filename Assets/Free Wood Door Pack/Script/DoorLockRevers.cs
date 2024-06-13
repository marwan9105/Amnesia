using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorLockReversScript
{
    [RequireComponent(typeof(AudioSource))]
    public class DoorLockRevers : MonoBehaviour
    {
        public bool open;
        public float smooth = 1.0f;
        float DoorOpenAngle = 90.0f;
        float DoorCloseAngle = -180.0f;
        public AudioSource asource;
        public AudioClip openDoor, closeDoor;

        private PadLockPassword padLock;

        void Start()
        {
            asource = GetComponent<AudioSource>();
            padLock = FindObjectOfType<PadLockPassword>();
        }

        void Update()
        {
            // Vérifie si le code est correct et ouvre la porte automatiquement
            if (padLock != null && padLock.isPasswordCorrect && !open)
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
        }

        public void CloseDoor()
        {
            open = false; // Pour permettre de refermer la porte si nécessaire
            asource.clip = closeDoor;
            asource.Play();
        }
    }
}
