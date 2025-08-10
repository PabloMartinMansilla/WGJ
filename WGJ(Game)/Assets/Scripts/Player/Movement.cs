using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Velocidad de movimiento
    public Camera playerCamera;        // Cámara que sigue al jugador
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private Vector3 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Bloquea el cursor en el centro y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento con WASD
        float moveX = Input.GetAxis("Horizontal"); // A/D
        float moveZ = Input.GetAxis("Vertical");   // W/S
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Rotación con el mouse (solo en el eje Y para el jugador)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        Vector3 move = transform.TransformDirection(moveDirection) * moveSpeed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}
