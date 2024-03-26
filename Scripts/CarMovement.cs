using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento predeterminada
    public float rotateSpeed = 100f; // Velocidad de rotación

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    float horizontalInput = Input.GetAxis("Horizontal");
    // Rotar el objeto según la entrada horizontal
    transform.Rotate(Vector3.up * horizontalInput * rotateSpeed * Time.deltaTime);
    // Si se presiona la tecla A, mover hacia la izquierda
    if (Input.GetKey(KeyCode.A))
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
    }
    // Si se presiona la tecla D, mover hacia la derecha
    else if (Input.GetKey(KeyCode.D))
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
    }
    // Si no se presiona ninguna tecla, mover hacia adelante
    else
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}

}
