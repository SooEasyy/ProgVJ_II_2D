using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void Reintentar()
    {
        // ? Ahora usamos GameManager
        GameManager.Instance.Reintentar();
    }

    public void IrAlMenu()
    {
        // ? Usamos GameManager
        GameManager.Instance.VolverAlMenu();
    }

    public void IrAlSiguienteNivel()
    {
        int siguienteNivel = ProgressManager.Instance.progresoData.ObtenerSiguienteNivel();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel " + siguienteNivel);
    }

    public void NuevoJuego()
    {
        // ? Para el botón Jugar en la portada
        GameManager.Instance.NuevoJuego();
    }

    public void SalirJuego()
    {
        Debug.Log("Cerrando el juego...");

        // Funciona en build
        Application.Quit();

#if UNITY_EDITOR
        // Solo para que funcione dentro del editor
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
