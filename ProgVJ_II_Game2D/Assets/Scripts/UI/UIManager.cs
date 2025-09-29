using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Reintentar()
    {
        Scene actual = SceneManager.GetActiveScene();
        // si perdiste o ganaste, volvemos al primer nivel (ej: "Nivel1")
        SceneManager.LoadScene("Nivel 1");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Portada");
    }
    public void IrAlSiguienteNivel()
    {
        int siguienteNivel = ProgressManager.Instance.progresoData.ObtenerSiguienteNivel();
        SceneManager.LoadScene("Nivel " + siguienteNivel);
    }

    public void SalirJuego()
    {
        Debug.Log("Cerrando el juego...");

        // Funciona en build
        Application.Quit();

    }
}
