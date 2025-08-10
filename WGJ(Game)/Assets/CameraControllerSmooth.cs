using UnityEngine;

public class CameraControllerSmooth : MonoBehaviour
{
    [Header("Objetivo / Escenario")]
    public Transform target;                  // Centro del cubo/escenario

    [Header("Vista isométrica")]
    [Range(10f, 60f)] public float pitch = 30f; // Inclinación
    public Vector3 offset = new Vector3(0, 10, -10); // Offset base (se rota en Y)

    [Header("Rotación por caras")]
    public float stepDegrees = 90f;           // Tamaño del paso por cara
    public float smoothTime = 0.25f;          // Tiempo de alisado (0.2–0.35 va bien)
    public bool snapOnStart = true;           // Coloca la cámara alineada al inicio

    private float desiredYaw;                 // Objetivo en Y (múltiplos de stepDegrees)
    private float yaw;                        // Yaw actual en Y
    private float yawVelocity;                // Estado interno de SmoothDampAngle

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraControllerSmooth: asigna el 'target' en el inspector.");
            enabled = false;
            return;
        }

        if (snapOnStart)
        {
            // Alinea al múltiplo más cercano desde la rotación inicial
            desiredYaw = Mathf.Round(transform.eulerAngles.y / stepDegrees) * stepDegrees;
            yaw = desiredYaw;
        }
        else
        {
            // Parte desde donde esté la cámara
            yaw = transform.eulerAngles.y;
            desiredYaw = yaw;
        }

        // Coloca la cámara correctamente en el primer frame
        UpdateCameraImmediate();
    }

    void Update()
    {
        // Entrada por pasos: A = girar a la izquierda, D = girar a la derecha
        if (Input.GetKeyDown(KeyCode.A))
            desiredYaw -= stepDegrees;

        if (Input.GetKeyDown(KeyCode.D))
            desiredYaw += stepDegrees;
    }

    void LateUpdate()
    {
        // Suavizado del ángulo hacia el objetivo
        yaw = Mathf.SmoothDampAngle(yaw, desiredYaw, ref yawVelocity, smoothTime);

        // Calcula posición y lookAt en una órbita isométrica
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = target.position + rot * offset;
        transform.LookAt(target, Vector3.up);
    }

    private void UpdateCameraImmediate()
    {
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = target.position + rot * offset;
        transform.LookAt(target, Vector3.up);
    }
}
