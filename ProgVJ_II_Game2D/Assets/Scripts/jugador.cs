using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion de Atributos")]
    [SerializeField]
    [Range(0, 50)]
    private int vida = 50;
    public int Vida { get => vida; set => vida = value; }

    [SerializeField]
    private UnityEvent<int> OnLivesChanged = new UnityEvent<int>();

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    private void Start()
    {
        OnLivesChanged.Invoke(Vida);
    }

    public void ModificarVida(int puntos)
    {
        Vida += puntos;
        OnTextChanged.Invoke(Vida.ToString());
        OnLivesChanged.Invoke(Vida);
        Debug.Log(EstasVivo());
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}
