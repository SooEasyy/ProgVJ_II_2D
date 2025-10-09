using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private int da�o = -1;
    [SerializeField] private float tiempoVida = 3f;

    private void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jugador jugador = collision.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.ModificarVida(da�o);
            }

            Destroy(gameObject);
        }
    }
}