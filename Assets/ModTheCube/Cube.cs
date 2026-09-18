using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [Header("Rotation Settings")]
    public float rotationSpeed = 50.0f;
    public Vector3 rotationAxis = new Vector3(1.0f, 1.0f, 0.0f);

    [Header("Color Transition Settings")]
    public float colorChangeSpeed = 0.5f;

    private Material cubeMaterial;

    void Start()
    {
        // 1. Posición aleatoria en X e Y al iniciar la escena
        float randomX = Random.Range(-5.0f, 5.0f);
        float randomY = Random.Range(1.0f, 5.0f);
        transform.position = new Vector3(randomX, randomY, 1.0f);

        // 2. Escala aleatoria entre 0.8 y 2.0
        float randomScale = Random.Range(0.8f, 2.0f);
        transform.localScale = Vector3.one * randomScale;

        // Guardar referencia del material
        if (Renderer != null)
        {
            cubeMaterial = Renderer.material;
        }
    }

    void Update()
    {
        // 3. Rotación continua en los ejes configurados
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        // 4. Funcionalidad extra: Cambio continuo y suave de color en el tiempo
        if (cubeMaterial != null)
        {
            // Calcula un tono de color (Hue) dinámico basado en el tiempo transcurrido
            float hue = Mathf.PingPong(Time.time * colorChangeSpeed, 1.0f);
            Color newColor = Color.HSVToRGB(hue, 0.8f, 1.0f);

            // Mantener la opacidad (canal Alpha) en 0.4f
            newColor.a = 0.4f;

            cubeMaterial.color = newColor;
        }
    }
}
