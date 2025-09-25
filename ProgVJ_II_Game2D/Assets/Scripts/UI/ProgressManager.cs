using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    [Header("Referencia al ScriptableObject de Progreso")]
    public ProgresoData progresoData; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            progresoData = new ProgresoData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetearProgreso()
    {
        progresoData.nivelActual = 1;
        progresoData.vidas = progresoData.vidasIniciales;
    }
}
