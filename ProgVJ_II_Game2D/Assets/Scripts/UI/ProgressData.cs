using UnityEngine;

[CreateAssetMenu(fileName = "ProgresoData", menuName = "Juego/ProgresoData")]
public class ProgresoData : ScriptableObject
{
    [Header("Configuración del Progreso")]
    public int nivelActual = 1;
    public int vidasIniciales = 5;
    public int vidas;
    public int estrellas = 0;

    public void ResetearProgreso()
    {
        nivelActual = 1;
        vidas = vidasIniciales;
        estrellas = 0;
    }
    public int ObtenerSiguienteNivel()
    {
        nivelActual++;
        return nivelActual;
    }

    public void AgregarEstrella()
    {
        estrellas++;
    }

}
