using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decisions : MonoBehaviour
{
    [Header("Referencias")]
    public DialogueTrigger currentDialogueTrigger;
    public MonoBehaviour[] playerScripts;  // Scripts jugador a desactivar/activar
    public GameObject secondCanvas;        // Canvas decisiones

    private void OnEnable()
    {
        if (currentDialogueTrigger != null && currentDialogueTrigger.IsDecisions)
        {
            secondCanvas.SetActive(true);
        }

        foreach (var script in playerScripts)
            script.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseDecisions()
    {
        gameObject.SetActive(false); // Esto dispara OnDisable()
    }

    private void OnDisable()
    {
        secondCanvas.SetActive(false);

        foreach (var script in playerScripts)
            script.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ActivateDecisions(DialogueTrigger dialogueTrigger)
    {
        currentDialogueTrigger = dialogueTrigger;
        gameObject.SetActive(true);
    }
}
