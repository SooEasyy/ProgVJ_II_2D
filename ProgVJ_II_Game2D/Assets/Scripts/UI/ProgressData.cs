using UnityEngine;

[CreateAssetMenu(fileName = "ProgresoData", menuName = "Juego/ProgresoData")]
public class ProgresoData : ScriptableObject
{
    [Header("Configuración del Progreso")]
    public int nivelActual = 1;
    public int vidasIniciales = 5;
    public int vidas;
    public int estrellas = 0;

    private void OnEnable()
    {
        // Cada vez que se usa, inicializamos las vidas
        vidas = vidasIniciales;
    }
        public int ObtenerSiguienteNivel()
    {
        nivelActual++;
        return nivelActual;
    }

}
