using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Tooltip("Nombre de la escena a cargar cuando se presione el bot�n")]
    public string sceneName;

    public void ButtonPlay()
    {
        //cambiar a la escena llamada Scene1
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("No se asign� el nombre de la escena en el inspector.");
        }
    }

    public void ButtonExit()
    {
        //Cerrar el juego
        Application.Quit();

        // Esto es para que tambi�n funcione en el editor de Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
