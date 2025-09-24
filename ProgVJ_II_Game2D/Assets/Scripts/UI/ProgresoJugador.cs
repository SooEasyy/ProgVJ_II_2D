// Scripts/TDA/ProgresoJugador.cs
public class ProgresoJugador
{
    public int nivel;
    public int vidas;
    private int puntaje;
    private int estrellas;
    public int nivelActual = 1;

    public ProgresoJugador()
    {
        nivel = 1;
        vidas = 5;
        puntaje = 0;
        estrellas = 0;
    }

    // --- Métodos de juego ---
    public void SumarPuntos(int puntos) => puntaje += puntos;
    public void PerderVida() { if (vidas > 0) vidas--; }
    public void GanarVida() => vidas++;
    public void AgregarEstrella() => estrellas++;
    public void SubirNivel() => nivel++;

    // --- Getters ---
    public int GetNivel() => nivel;
    public int GetVidas() => vidas;
    public int GetPuntaje() => puntaje;
    public int GetEstrellas() => estrellas;
    public int ObtenerSiguienteNivel()
    {
        nivelActual++;
        return nivelActual;
    }
}