using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Decisions decisions;                 // Referencia al script Decisions
    public bool IsDecisions;                    // Indica si este NPC tiene decisiones
    public Canvas dialogueCanvas;               // Canvas diálogo
    public TextMeshProUGUI dialogueText;        // Texto diálogo
    [TextArea] public List<string> dialogues;  // Lista de diálogos

    private int currentDialogueIndex = 0;
    private bool playerInside = false;
    private bool dialogueFinished = false;

    private void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInside && !dialogueFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentDialogueIndex++;

                if (currentDialogueIndex < dialogues.Count)
                {
                    dialogueText.text = dialogues[currentDialogueIndex];
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            dialogueFinished = false;           // Reset para poder repetir diálogo
            dialogueCanvas.gameObject.SetActive(true);
            currentDialogueIndex = 0;
            dialogueText.text = dialogues[currentDialogueIndex];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            dialogueCanvas.gameObject.SetActive(false);
        }
    }

    private void EndDialogue()
    {
        dialogueFinished = true;
        dialogueCanvas.gameObject.SetActive(false);

        if (IsDecisions && decisions != null)
            decisions.ActivateDecisions(this);

        Destroy(gameObject);
    }
}
