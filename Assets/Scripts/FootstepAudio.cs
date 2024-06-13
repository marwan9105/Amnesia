using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f; // Intervalle de temps entre chaque pas

    private AudioSource audioSource;
    private float stepTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HandleFootstep(bool isWalking, bool isGrounded)
    {
        if (isWalking && isGrounded)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    private void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index]);
        }
    }
}
