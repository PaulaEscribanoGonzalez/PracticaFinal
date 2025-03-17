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
            DestruirPared(); // Llama a la funci�n de destrucci�n
        }
    }

    void DestruirPared()
    {
        GetComponent<Rigidbody>().isKinematic = false; // Desactiva "Is Kinematic" para que caiga
        Destroy(gameObject, 2f); // Destruir la pared despu�s de 2 segundos
    }
}
