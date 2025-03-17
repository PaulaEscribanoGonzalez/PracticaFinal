using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int velocidad; // Velocidad de movimiento
    public int velocidadRotacion; // Velocidad de giro

    private int velocidadInicial;

    void Start()
    {
        velocidadInicial = velocidad;
    }

    void Update()
    {
        // Avanzar y retroceder (Eje Z)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
        }

        // Moverse lateralmente (Eje X)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
    }
}
