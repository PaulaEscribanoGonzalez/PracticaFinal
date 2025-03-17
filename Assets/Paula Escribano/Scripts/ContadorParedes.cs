using UnityEngine;
using TMPro; // Necesario para manejar el texto UI

public class ContadorParedes : MonoBehaviour
{
    public TextMeshProUGUI contadorText;  // Texto del contador
    public TextMeshProUGUI mensajeGanador; // Texto "¡Ganaste!" (asignar en Inspector)

    private int paredesDerribadas = 0; // Contador de paredes derribadas
    private int totalParedes; // Número total de paredes en la escena

    void Start()
    {
        // Asegurar que cuenta TODAS las paredes al inicio del juego
        totalParedes = GameObject.FindGameObjectsWithTag("obstaculo").Length;

        mensajeGanador.gameObject.SetActive(false); // Ocultar mensaje al inicio
        Debug.Log("Total de paredes en escena: " + totalParedes); // Verificar número en consola
    }


    void OnEnable()
    {
        Obstaculo.OnObstaculoColisionado += AumentarContador; // Suscribirse al evento
    }

    void OnDisable()
    {
        Obstaculo.OnObstaculoColisionado -= AumentarContador; // Desuscribirse al evento
    }

    void AumentarContador()
    {
        paredesDerribadas++; // Aumentar el contador
        contadorText.text = "Puntuación: " + paredesDerribadas; // Actualizar UI

        if (paredesDerribadas >= totalParedes) // Si todas las paredes caen
        {
            MostrarMensajeGanador();
        }
    }

    void MostrarMensajeGanador()
    {
        mensajeGanador.gameObject.SetActive(true); // Mostrar "¡Ganaste!"
    }
}


