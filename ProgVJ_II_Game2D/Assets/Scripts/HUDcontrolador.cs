using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI miTexto;

    public void ActualizarTextoHUD(int vidas)
    {
        if (miTexto == null)
        {
            Debug.LogError("HUDController: miTexto no está asignado en el inspector!");
            return;
        }

        Debug.Log("Actualizando HUD con vidas = " + vidas);
        miTexto.text = vidas.ToString();
    }
}
