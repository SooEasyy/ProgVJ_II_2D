using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto = 12f;
    [SerializeField] private AudioClip jumpSFX;

    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;
    private bool puedeSaltar = false;

    void Start()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            puedeSaltar = false;

            if (jumpSFX != null)
                miAudioSource.PlayOneShot(jumpSFX);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            puedeSaltar = true;
        }
    }
}
