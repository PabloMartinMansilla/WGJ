using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenePluma : MonoBehaviour
{
    public float fadeDuration = 2f;          // Tiempo de la transición
    public string nextSceneName = "Scene2";  // Nombre de la siguiente escena
    public Image fadeImage;                  // Imagen negra
    public AudioSource audioSource;          // Audio de transición

    private void Awake()
    {
        // Si no está asignada la imagen, buscarla por nombre
        if (fadeImage == null)
        {
            GameObject obj = GameObject.Find("END image");
            if (obj != null)
                fadeImage = obj.GetComponent<Image>();
        }

        // Forzar transparencia inicial
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        // Buscar el audio en este mismo objeto si no está asignado
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndChangeScene());
        }
    }

    private IEnumerator FadeAndChangeScene()
    {
        if (audioSource != null)
            audioSource.Play();

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);

            if (fadeImage != null)
            {
                Color c = fadeImage.color;
                c.a = alpha;
                fadeImage.color = c;
                Debug.Log($"Alpha: {alpha}");
            }
            else
            {
                Debug.LogError("fadeImage es NULL");
                yield break;  // mejor salir de la coroutine
            }

            yield return null;  // <---- importante para que la transición se vea gradual
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
