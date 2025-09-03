using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;

    public void ActualizarVidasHUD (int vidas)
    {
        Debug.Log("ESTAS ACTUALIZANDO VIDAS");
        if (EstaVacioContenedor())
        {
            CargarContenedor(vidas);
            return;
        }

        if (CantidadIconosVida()>vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
    }

    private bool EstaVacioContenedor()
    {
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVida()
    {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor (int cantidadIconos)
    {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorIconosVida.transform);
    }
}
