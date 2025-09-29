using UnityEngine;
using UnityEngine.SceneManagement; // para cambiar escenas

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NuevoJuego()
    {
        ProgressManager.Instance.progresoData.ResetearProgreso();

        SceneManager.LoadScene("Nivel 1");
    }

    public void Reintentar()
    {
        ProgressManager.Instance.progresoData.vidas = ProgressManager.Instance.progresoData.vidasIniciales;

        int nivelActual = ProgressManager.Instance.progresoData.nivelActual;

        string nombreEscena = "Nivel " + nivelActual;

        SceneManager.LoadScene(nombreEscena);
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Portada");
    }
    public void Win()
    {
        Debug.Log("Ganaste!");
        SceneManager.LoadScene("Victoria"); 
    }

    public void CheckLose(int vida)
    {
        if (vida <= 0)
        {
            Debug.Log("Perdiste!");
            SceneManager.LoadScene("Derrota"); 
        }
    }
}
