using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderAction : MonoBehaviour
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
}
