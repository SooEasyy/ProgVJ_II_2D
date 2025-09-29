using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker Instance;

    public string EscenaActual { get; private set; }
    public string EscenaAnterior { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            EscenaActual = SceneManager.GetActiveScene().name;
            EscenaAnterior = ""; // No hay anterior al inicio

            // Nos suscribimos al evento de cambio de escena
            SceneManager.activeSceneChanged += OnSceneChanged;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        EscenaAnterior = oldScene.name;
        EscenaActual = newScene.name;
    }
}
