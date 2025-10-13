using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProgresoData", menuName = "Juego/ProgresoData")]
public class ProgresoData : ScriptableObject
{
    [Header("Configuración del Progreso")]
    public int nivelActual = 1;
    public int vidasIniciales = 5;
    public int vidas;
    public int estrellas = 0;

    public List<string> estrellasRecolectadas = new List<string>();
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

    public void AgregarEstrella(string idEstrella)
    {
        if (!estrellasRecolectadas.Contains(idEstrella))
        {
            estrellas++;
            estrellasRecolectadas.Add(idEstrella);
        }
    }

    public bool FueRecolectada(string idEstrella)
    {
        return estrellasRecolectadas.Contains(idEstrella);
    }

    public void ReiniciarEstrellas()
    {
        estrellasRecolectadas.Clear();
    }

}
