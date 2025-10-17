
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;

    [Header("Sonido de daño")]
    [SerializeField] private AudioClip collisionSFX; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // si el enemigo no tiene AudioSource, se lo agregamos dinámicamente
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            audioSource.PlayOneShot(collisionSFX);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
        }
    }
}