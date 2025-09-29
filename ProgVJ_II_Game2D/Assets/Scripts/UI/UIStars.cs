using TMPro;
using UnityEngine;

public class UIStars : MonoBehaviour
{
    public static UIStars Instance { get; private set; }

    [SerializeField] private TMP_Text textoCantidad;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ActualizarEstrellas(ProgressManager.Instance.progresoData.estrellas);
    }

    public void ActualizarEstrellas(int cantidad)
    {
        textoCantidad.text = "x " + cantidad;
    }
}
