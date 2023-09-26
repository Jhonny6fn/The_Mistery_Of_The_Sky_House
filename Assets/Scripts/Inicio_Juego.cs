using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio_Juego : MonoBehaviour
{
    public GameObject menu_inicio;
    public GameObject Canon, Canon2;
    public GameObject PauseManager;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Canon.GetComponent<MovimientoCanyon>().enabled = false;
        Canon2.GetComponent<MovimientoCilindro>().enabled = false;
    }

    public void start_game()
    {
        menu_inicio.SetActive(false);
        Canon.GetComponent<MovimientoCanyon>().enabled = true;
        Canon2.GetComponent<MovimientoCilindro>().enabled = true;
        PauseManager.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}