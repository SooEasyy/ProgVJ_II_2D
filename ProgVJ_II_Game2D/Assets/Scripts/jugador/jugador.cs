using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Sonidos del jugador")]
    [SerializeField] private AudioClip sonidoCañon;

    [SerializeField]
    private UnityEvent<int> OnLivesChanged = new UnityEvent<int>();
    private ProgresoData progreso;

    private void Start()
    {
        progreso = ProgressManager.Instance.progresoData;
        OnLivesChanged.Invoke(progreso.vidas);
    }

    public void ModificarVida(int puntos)
    {
        progreso.vidas += puntos;
        OnLivesChanged.Invoke(progreso.vidas);

        if (!EstasVivo())
        {
            GameManager.Instance.CheckLose(progreso.vidas);
        }
    }

    private bool EstasVivo()
    {
        return progreso.vidas > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var progreso = ProgressManager.Instance.progresoData;

        switch (collision.gameObject.tag)
        {
            case "Meta":
                GameManager.Instance.Win();
                break;

            case "Cañon":
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(Vector2.up * 500f);
                }

                if (sonidoCañon != null)
                    AudioSource.PlayClipAtPoint(sonidoCañon, transform.position);
                break;

            default:
                // objetos sin etiqueta específica -> no hacen nada
                break;
        }
    }

}
