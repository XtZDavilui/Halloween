using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxColliderAction : MonoBehaviour
{
    public AudioSource soundSource; // Referencia al componente AudioSource del sonido
    public Image image;  // Referencia al componente Image de la imagen a controlar
    public float fadeInDuration = 1.0f;  // Duración de la animación de aparecer
    public float fadeOutDuration = 1.0f;  // Duración de la animación de desaparecer

    private bool fadeInStarted = false;
    private bool fadeOutStarted = false;
    private float currentAlpha = 0.0f;

    void Start()
    {
        if (image == null)
        {
            Debug.LogError("Image component is not assigned.");
            return;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);  // Inicialmente transparente
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Puedes cambiar la etiqueta para que coincida con tu jugador u otro objeto
        {
            fadeInStarted = true;
            fadeOutStarted = false;

            // Reproducir el sonido si el AudioSource está asignado
            if (soundSource != null)
            {
                soundSource.Play();
            }
        }
    }

    void Update()
    {
        if (fadeInStarted)
        {
            currentAlpha += Time.deltaTime / fadeInDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha >= 1.0f)
            {
                fadeInStarted = false;
            }
        }
        if (fadeOutStarted)
        {
            currentAlpha -= Time.deltaTime / fadeOutDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha <= 0.0f)
            {
                fadeOutStarted = false;
                image.gameObject.SetActive(false);
            }
        }
    }
}
/*public class BoxColliderAction : MonoBehaviour
{
    public AudioSource soundSource; // Referencia al componente AudioSource del sonido
    public Image image;  // Referencia al componente Image de la imagen a controlar
    public float fadeInDuration = 1.0f;  // Duración de la animación de aparecer
    public float fadeOutDuration = 1.0f;  // Duración de la animación de desaparecer

    private bool fadeInStarted = false;
    private bool fadeOutStarted = false;
    private float currentAlpha = 0.0f;

    void Start()
    {
        if (image == null)
        {
            Debug.LogError("Image component is not assigned.");
            return;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);  // Inicialmente transparente
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Puedes cambiar la etiqueta para que coincida con tu jugador u otro objeto
        {
            fadeInStarted = true;
            fadeOutStarted = false;
        }
    }

    void Update()
    {
        if (fadeInStarted)
        {
            currentAlpha += Time.deltaTime / fadeInDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha >= 1.0f)
            {
                fadeInStarted = false;
            }
        }
        if (fadeOutStarted)
        {
            currentAlpha -= Time.deltaTime / fadeOutDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha <= 0.0f)
            {
                fadeOutStarted = false;
                image.gameObject.SetActive(false);
            }
        }
    }
}*///Este es el mejor por ahorita

/*public class BoxColliderAction : MonoBehaviour
{
    public AudioSource soundSource; // Referencia al componente AudioSource del sonido
    public Image image;  // Referencia al componente Image de la imagen a controlar
    public float fadeInDuration = 1.0f;  // Duración de la animación de aparecer
    public float waitDuration = 1.0f;   // Duración de espera antes de desaparecer
    public float fadeOutDuration = 1.0f;  // Duración de la animación de desaparecer

    private float currentAlpha = 0.0f;
    private bool fadeInStarted = false;
    private bool fadeOutStarted = false;

    void Start()
    {
        if (image == null)
        {
            Debug.LogError("Image component is not assigned.");
            return;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);  // Inicialmente transparente
        Invoke("StartFadeIn", 0.5f);  // Retraso para empezar la animación
    }

    void StartFadeIn()
    {
        fadeInStarted = true;
        fadeOutStarted = false;
    }

    void Update()
    {
        if (fadeInStarted)
        {
            currentAlpha += Time.deltaTime / fadeInDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha >= 1.0f)
            {
                fadeInStarted = false;
                Invoke("StartFadeOut", waitDuration);
            }
        }

        if (fadeOutStarted)
        {
            currentAlpha -= Time.deltaTime / fadeOutDuration;
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha <= 0.0f)
            {
                fadeOutStarted = false;
                image.gameObject.SetActive(false);
            }
        }
    }

    void StartFadeOut()
    {
        fadeInStarted = false;
        fadeOutStarted = true;
    }
}*/

/*public class BoxColliderAction : MonoBehaviour
{
    public AudioSource soundSource; // Referencia al componente AudioSource del sonido
    public GameObject imageObject;  // Referencia al GameObject de la imagen a activar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Puedes cambiar la etiqueta para que coincida con tu jugador u otro objeto
        {
            // Activar el sonido si está asignado
            if (soundSource != null)
            {
                soundSource.Play();
            }

            // Activar la imagen si el GameObject está asignado
            if (imageObject != null)
            {
                imageObject.SetActive(true);
            }
        }
    }
}*/
