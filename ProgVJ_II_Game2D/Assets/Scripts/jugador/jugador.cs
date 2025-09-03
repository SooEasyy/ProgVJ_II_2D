using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion de Atributos")]
    [SerializeField]
    [Range(0, 10)]
    private int vida = 5;
    public int Vida { get => vida; set => vida = value; }

    [SerializeField]
    private UnityEvent<int> OnLivesChanged = new UnityEvent<int>();

    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        OnLivesChanged.Invoke(Vida);
    }

    public void ModificarVida(int puntos)
    {
        Vida += puntos;
        OnLivesChanged.Invoke(Vida);

        if (!EstasVivo())
        {
            GameManager.Instance.CheckLose(vida);
        }
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        {
            GameManager.Instance.Win();
        }
    }
}
