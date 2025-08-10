using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decisions : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject player;              // Objeto del jugador
    public MonoBehaviour[] playerScripts;  // Scripts del jugador que se van a desactivar/activar
    public GameObject secondCanvas;        // El segundo Canvas que se activará

    private void OnEnable()
    {

        // Desactivar scripts del jugador
        foreach (var script in playerScripts)
        {
            script.enabled = false;
        }

        // Mostrar el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        // Activar el segundo Canvas
        if (secondCanvas != null)
        {
            secondCanvas.SetActive(true);
        }
    }
}
