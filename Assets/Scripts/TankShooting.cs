using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil (debes asignarlo en el Inspector)
    public Transform puntoDisparo; // Punto desde donde se dispara el proyectil
    public float velocidadProyectil = 20f; // Velocidad del proyectil
    public float tiempoEntreDisparos = 0.3f; // Cadencia de disparo

    private float tiempoUltimoDisparo;

    void Update()
    {
        // Si presionamos Espacio y ha pasado el tiempo necesario, disparamos
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        // Instanciamos el proyectil en el punto de disparo con la misma rotación
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Añadimos fuerza al proyectil para que avance
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = puntoDisparo.forward * velocidadProyectil;
        }

        // Destruir el proyectil después de 3 segundos para optimizar
        Destroy(proyectil, 3f);
    }
}
