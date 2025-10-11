using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoVida = 3f;

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;


    private Vector2 direccion = Vector2.right; // ?? dirección por defecto

    private void OnEnable()
    {
        Invoke(nameof(Desactivar), tiempoVida);
    }

    private void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var jugador = collision.GetComponent<Jugador>();
            if (jugador != null)
            {
                jugador.ModificarVida(-1);
            }

            Desactivar();
        }
    }

    private void Desactivar()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

    public void SetDireccion(Vector2 nuevaDireccion)
    {
        direccion = nuevaDireccion;
    }
}