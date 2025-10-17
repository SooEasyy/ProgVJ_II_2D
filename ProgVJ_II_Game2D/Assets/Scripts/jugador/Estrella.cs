using UnityEngine;

public class Estrella : MonoBehaviour
{
    [SerializeField] private string idEstrella = "";

    [Header("Sonido de recolección")]
    [SerializeField] private AudioClip collectSFX;

    private ProgresoData progreso;
    private void Start()
    {
        // Si ya fue recolectada antes, la desactivamos
        if (ProgressManager.Instance.progresoData.FueRecolectada(idEstrella))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProgressManager.Instance.progresoData.AgregarEstrella(idEstrella);
            UIStars.Instance.ActualizarEstrellas(ProgressManager.Instance.progresoData.estrellas);

            if (collectSFX != null)
            {
                AudioSource.PlayClipAtPoint(collectSFX, transform.position);
            }

            gameObject.SetActive(false); 
        }
    }
}
