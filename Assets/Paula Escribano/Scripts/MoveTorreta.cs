using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTorreta : MonoBehaviour
{
    public float velocidadMovimiento = 2f; // Velocidad de movimiento vertical
    public float limiteInferior = 0f; // Altura mínima
    public float limiteSuperior = 5f; // Altura máxima

    public Transform cuboTorreta;  // Referencia al cubo de la torreta (deberás asignarlo en el Inspector)

    private float rotacionVertical = 0f; // Control de la rotación vertical del cubo
    public float velocidadRotacion = 100f; // Velocidad de rotación

    void Update()
    {
        // 🔄 Rotación horizontal con Q y W
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -velocidadMovimiento * 50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up, velocidadMovimiento * 50f * Time.deltaTime);
        }

        // 🎯 Rotación vertical (inclinación) con E y R (en el eje Z)
        if (Input.GetKey(KeyCode.E))
        {
            rotacionVertical += velocidadRotacion * Time.deltaTime; // Rotar hacia arriba
        }
        if (Input.GetKey(KeyCode.R))
        {
            rotacionVertical -= velocidadRotacion * Time.deltaTime; // Rotar hacia abajo
        }

        // Aplicar límites de rotación al cubo de la torreta
        rotacionVertical = Mathf.Clamp(rotacionVertical, limiteInferior, limiteSuperior);

        // Aplicar la rotación vertical al cubo de la torreta en el eje Z
        cuboTorreta.localRotation = Quaternion.Euler(cuboTorreta.localRotation.eulerAngles.x, cuboTorreta.localRotation.eulerAngles.y, rotacionVertical);
    }
}
