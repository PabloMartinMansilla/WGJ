using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDialogue : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger; // Referencia al DialogueTrigger de este NPC
    public GameObject prefabToSpawn;        // Prefab que se va a instanciar
    public Transform spawnPoint;            // Lugar donde aparecerá (si no se asigna, será en la posición del NPC)

    private void Update()
    {
        // Si el DialogueTrigger ya fue destruido, este campo queda null
        if (dialogueTrigger == null)
        {
            SpawnPrefab();
            Destroy(this); // Destruir este script para que no se siga ejecutando
        }
    }

    private void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

            Instantiate(prefabToSpawn, position, rotation);
        }
    }
}
