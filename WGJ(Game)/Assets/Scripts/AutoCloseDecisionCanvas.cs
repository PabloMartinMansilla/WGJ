using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCloseDecisionCanvas : MonoBehaviour
{
    public float timeout = 5f; // Tiempo en segundos
    private float timer;
    public GameObject canvasDialogue;

    private void OnEnable()
    {
        timer = 0f; // Resetea el contador cada vez que se activa el canvas
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeout)
        {
            gameObject.SetActive(false); // Cierra el canvas
            canvasDialogue.SetActive(false);
        }
    }
}
