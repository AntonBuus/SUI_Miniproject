using UnityEngine;

public class RadioController : MonoBehaviour
{
    // we put this on the radio (on a XR simple interactable) to allow the player to toggle the radio sound
    public AudioSource audioSource;

    public void SoundToggle()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
