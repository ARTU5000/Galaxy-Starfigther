using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] botonInicialNuevo;
    // Start is called before the first frame update

    public void BHUD_Bg()
    {
        // Limpia cualquier selección actual
        EventSystem.current.SetSelectedGameObject(null);

        // Establece el nuevo botón como seleccionado
        EventSystem.current.SetSelectedGameObject(botonInicialNuevo[0]);
    }

    public void BHUD_PlayerNum()
    {
        // Limpia cualquier selección actual
        EventSystem.current.SetSelectedGameObject(null);

        // Establece el nuevo botón como seleccionado
        EventSystem.current.SetSelectedGameObject(botonInicialNuevo[1]);
    }

    public void BHUD_Custom()
    {
        // Limpia cualquier selección actual
        EventSystem.current.SetSelectedGameObject(null);

        // Establece el nuevo botón como seleccionado
        EventSystem.current.SetSelectedGameObject(botonInicialNuevo[2]);
    }
}
