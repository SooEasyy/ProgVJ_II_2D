using System.Collections;
using UnityEngine;

public class GeneradorProyectiles : MonoBehaviour
{
    [Header("Configuración del disparo")]
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float tiempoInicial = 1f;
    [SerializeField] private float intervaloDisparo = 2f;
    [SerializeField] private float fuerzaDisparo = 5f;

    private void Start()
    {
        StartCoroutine(Disparar());
    }

    private IEnumerator Disparar()
    {
        yield return new WaitForSeconds(tiempoInicial);

        while (true)
        {
            GameObject nuevoProyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = nuevoProyectil.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Dispara hacia la izquierda o derecha según la orientación del enemigo
                Vector2 direccion = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
                rb.AddForce(direccion * fuerzaDisparo, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(intervaloDisparo);
        }
    }
}
