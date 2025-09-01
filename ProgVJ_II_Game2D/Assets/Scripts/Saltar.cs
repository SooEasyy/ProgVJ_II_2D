using UnityEngine;

public class Saltar : MonoBehaviour
{
    public float FuerzaSalto = 12f;
    private Rigidbody2D miRigidbody2D;
    private bool puedeSaltar = false;

    void Start()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            miRigidbody2D.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Solo permite saltar si tocamos algo con etiqueta "Suelo"
        if (col.gameObject.CompareTag("Untagged"))
        {
            puedeSaltar = true;
        }
    }
}
