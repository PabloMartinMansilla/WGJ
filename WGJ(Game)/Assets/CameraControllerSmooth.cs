using UnityEngine;

public class CameraControllerSmooth : MonoBehaviour
{
    [Header("Objetivo / Escenario")]
    public Transform target;                  // Centro del cubo/escenario

    [Header("Vista isom�trica")]
    [Range(10f, 60f)] public float pitch = 30f; // Inclinaci�n
    public Vector3 offset = new Vector3(0, 10, -10); // Offset base (se rota en Y)

    [Header("Rotaci�n por caras")]
    public float stepDegrees = 90f;           // Tama�o del paso por cara
    public float smoothTime = 0.25f;          // Tiempo de alisado (0.2�0.35 va bien)
    public bool snapOnStart = true;           // Coloca la c�mara alineada al inicio

    private float desiredYaw;                 // Objetivo en Y (m�ltiplos de stepDegrees)
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
            // Alinea al m�ltiplo m�s cercano desde la rotaci�n inicial
            desiredYaw = Mathf.Round(transform.eulerAngles.y / stepDegrees) * stepDegrees;
            yaw = desiredYaw;
        }
        else
        {
            // Parte desde donde est� la c�mara
            yaw = transform.eulerAngles.y;
            desiredYaw = yaw;
        }

        // Coloca la c�mara correctamente en el primer frame
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
        // Suavizado del �ngulo hacia el objetivo
        yaw = Mathf.SmoothDampAngle(yaw, desiredYaw, ref yawVelocity, smoothTime);

        // Calcula posici�n y lookAt en una �rbita isom�trica
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
