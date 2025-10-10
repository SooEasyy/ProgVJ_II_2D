using UnityEngine;

public class EnemigoDispara : MonoBehaviour
{
    [Header("Configuración de disparo")]
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private float tiempoEntreDisparos = 2f;
    [SerializeField] private bool dispararHaciaIzquierda = false; 

    private void Start()
    {
        InvokeRepeating(nameof(Disparar), 1f, tiempoEntreDisparos);
    }

    private void Disparar()
    {
        GameObject proyectil = pooler.GetPooledObject();
        if (proyectil != null)
        {
            proyectil.transform.position = transform.position;
            proyectil.transform.rotation = transform.rotation;
            proyectil.SetActive(true);

            Proyectil script = proyectil.GetComponent<Proyectil>();
            if (script != null)
            {
                if (dispararHaciaIzquierda)
                    script.SetDireccion(Vector2.left);
                else
                    script.SetDireccion(Vector2.right);
            }
        }
    }
}
