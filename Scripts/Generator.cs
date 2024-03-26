using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform target; // Transform del auto
    public GameObject[] objectsToSpawn; // Array de objetos a lanzar
    public float spawnRate = 5f; // Tasa de generación de objetos (objetos por segundo)
    public float spawnHeight = 10f; // Altura desde la que aparecerán los objetos

    private float spawnTimer = 0f;

    void Update()
    {
        // Verificar si se ha asignado el transform del auto
        if (target == null)
        {
            Debug.LogWarning("El objeto target no está asignado en ObjectSpawner");
            return;
        }

        // Hacer que el objeto vacío siga al auto
        transform.position = target.position;

        // Contador de tiempo para la generación de objetos
        spawnTimer += Time.deltaTime;

        // Generar objetos aleatorios si ha pasado suficiente tiempo
        if (spawnTimer >= 1f / spawnRate)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        // Calcular una posición aleatoria en el plano XZ alrededor del objeto vacío
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), spawnHeight, Random.Range(-5f, 5f)) + transform.position;

        // Seleccionar un objeto aleatorio de la matriz de objetos para generar
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        // Generar el objeto en la posición calculada
        GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Agregar un componente Rigidbody al objeto generado
        Rigidbody rb = newObject.AddComponent<Rigidbody>();
        rb.useGravity = true; // Habilitar la gravedad
        rb.mass = 1f; // Asignar una masa al objeto para controlar la velocidad de caída
    }
}