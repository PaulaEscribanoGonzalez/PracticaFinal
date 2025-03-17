using UnityEngine;
using System; // Para eventos

public class Obstaculo : MonoBehaviour
{
    public static event Action OnObstaculoColisionado; // Evento global

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("proyectil")) // Si la bala impacta
        {
            OnObstaculoColisionado?.Invoke(); // Dispara el evento
            DestruirPared(); // Llama a la función de destrucción
        }
    }

    void DestruirPared()
    {
        GetComponent<Rigidbody>().isKinematic = false; // Desactiva "Is Kinematic" para que caiga
        Destroy(gameObject, 2f); // Destruir la pared después de 2 segundos
    }
}
