using UnityEngine;

public class ImpactoPared : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource de la pared
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("proyectil")) // Verifica si la colisión es con la bala
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // Reproduce el sonido
            }
        }
    }
}
