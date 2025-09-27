using UnityEngine;

public class Estrella : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProgressManager.Instance.progresoData.AgregarEstrella();
            UIStars.Instance.ActualizarEstrellas(ProgressManager.Instance.progresoData.estrellas);

            Destroy(gameObject);
        }
    }
}
