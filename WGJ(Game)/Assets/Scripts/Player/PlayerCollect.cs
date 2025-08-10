using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    public TextMeshProUGUI infoText;   // Texto TMP para mostrar el mensaje
    [TextArea] public string message; // Mensaje a mostrar
    private GameObject collectible;    // Referencia al objeto con el que colisionamos

    private void Start()
    {
        if (infoText != null)
            infoText.gameObject.SetActive(false); // Ocultamos el texto al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coleccionable");
        if (other.CompareTag("Coleccionable"))
        {
            collectible = other.gameObject;
            if (infoText != null)
            {
                infoText.text = message;
                infoText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            collectible = null;
            if (infoText != null)
                infoText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (collectible != null && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collectible);
            Debug.Log("se destruyo");
            collectible = null;

            if (infoText != null)
                infoText.gameObject.SetActive(false);
        }
    }
}
