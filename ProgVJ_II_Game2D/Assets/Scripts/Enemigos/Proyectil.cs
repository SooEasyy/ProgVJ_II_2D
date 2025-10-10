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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            jugador.ModificarVida(-puntos);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
        }
        Desactivar();
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