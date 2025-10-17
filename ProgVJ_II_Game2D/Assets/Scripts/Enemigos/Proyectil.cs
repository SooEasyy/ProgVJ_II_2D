using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoVida = 3f;

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;

    [Header("Sonido de impacto")]
    [SerializeField] private AudioClip collisionSFX;
    private AudioSource audioSource;

    private Vector2 direccion = Vector2.right; // ?? dirección por defecto
        private void Awake()
    {
        // Añadimos o usamos un AudioSource existente
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

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

                if (collisionSFX != null)
                {
                    AudioSource.PlayClipAtPoint(collisionSFX, transform.position);
                }
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