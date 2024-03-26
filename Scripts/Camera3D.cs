using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3D : MonoBehaviour
{
    public Transform target;
    public float distance = 10f; // Distancia desde atrás del vehículo
    public float height = 20f;   // Altura de la cámara sobre el vehículo

    // Update is called once per frame
    void Update()
    {
        // Calcula la posición deseada de la cámara
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;
        
        // Establece la posición de la cámara
        transform.position = targetPosition;
        
        // Hace que la cámara mire hacia el vehículo
        transform.LookAt(target);
    }
}
