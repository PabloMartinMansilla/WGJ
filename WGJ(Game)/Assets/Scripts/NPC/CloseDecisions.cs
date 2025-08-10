using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDecisions : MonoBehaviour
{
    [Header("Referencias")]
    public MonoBehaviour[] playerScripts;  // Scripts del jugador a activar

    private void OnDisable()
    {
        // Activar scripts del jugador
        foreach (var script in playerScripts)
        {
            script.enabled = true;
        }

        // Ocultar y bloquear el cursor en el centro
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
