using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip coin;
    public AudioClip step;
    public AudioClip damage;
    
    // boton izq mouse presionado
    // Sonido de coin en Play
    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coin);
    }
}