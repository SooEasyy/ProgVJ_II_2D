using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> OnLivesChanged = new UnityEvent<int>();
    private int vida = 5;
    public int Vida { get => vida; set => vida = value; }

    private void Start()
    {
        // ?? Recupero las vidas guardadas
        vida = ProgressManager.Instance.Progreso.vidas;
        OnLivesChanged.Invoke(Vida);
    }

    public void ModificarVida(int puntos)
    {
        Vida += puntos;
        ProgressManager.Instance.Progreso.vidas = Vida; // ?? Actualizo las vidas en el progreso

        OnLivesChanged.Invoke(Vida);

        if (!EstasVivo())
        {
            GameManager.Instance.CheckLose(vida);
        }
    }

    private bool EstasVivo()
    {
        return ProgressManager.Instance.Progreso.GetVidas() > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Meta":
                ProgressManager.Instance.Progreso.SubirNivel();
                GameManager.Instance.Win();
                break;

            case "Estrella":
                ProgressManager.Instance.Progreso.AgregarEstrella();
                Destroy(collision.gameObject);
                break;

            case "Cañon":
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(Vector2.up * 500f);
                }
                break;

            default:
                // objetos sin etiqueta específica -> no hacen nada
                break;
        }
    }
}
