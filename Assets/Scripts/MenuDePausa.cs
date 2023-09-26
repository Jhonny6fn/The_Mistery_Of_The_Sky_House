using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuDePausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public GameObject Canon, Camara, Camara2;
    public GameObject Boton1, Boton2;
    public GameObject GrabPass1, GrabPass2, GrabPass3, GrabPass4;
    public GameObject Boton1GB, Boton2GB;
    public GameObject Panel_Principal, Panel_Controles;

    public bool pausa, controles;
    public AudioSource avion, ambiente;

    public AudioMixer audioMixer;
    [SerializeField] Text Volume_Text;
    public Slider Slider_Sonido;
    float valor_sonido;

    public GameObject Mute_Music, Unmute_Music;

    void Update()
    {
        valor_sonido = Slider_Sonido.value * 100;
        Volume_Text.text = valor_sonido.ToString("0");

        if (Slider_Sonido.value <= 0.001)
        {
            Mute_Music.SetActive(true);
            Unmute_Music.SetActive(false);
        }

        if (Slider_Sonido.value > 0.001)
        {
            Mute_Music.SetActive(false);
            Unmute_Music.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false && controles == false)
            {
                MenuPausa.SetActive(true);
                Canon.GetComponent<MovimientoCanyon>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                avion.volume = 0.2f;
                ambiente.volume = 0.1f;
                StartCoroutine("cambiarBool");
            }

            if (pausa == true && controles == false)
            {
                BotonContinuar();
            }

            if (pausa == true && controles == true)
            {
                VolverDeControles();
            }
        }
    }
    public IEnumerator cambiarBool()
    {
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 0f;
        pausa = true;
    }

    public void BotonContinuar()
    {
        MenuPausa.SetActive(false);
        Canon.GetComponent<MovimientoCanyon>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        avion.volume = 0.6f;
        ambiente.volume = 0.3f;
        pausa = false;
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Sonido", Mathf.Log10(volume) * 20);
    }

    public void Desactivar_PostProcesado()
    {
        Camara.GetComponent<Efecto_PostProcesado>().enabled = false;
        Camara2.GetComponent<Efecto_PostProcesado>().enabled = false;
        Boton2.SetActive(true);
        Boton1.SetActive(false);
    }

    public void Activar_PostProcesado()
    {
        Camara.GetComponent<Efecto_PostProcesado>().enabled = true;
        Camara2.GetComponent<Efecto_PostProcesado>().enabled = true;
        Boton1.SetActive(true);
        Boton2.SetActive(false);
    }

    public void Controles()
    {
        Panel_Principal.SetActive(false);
        Panel_Controles.SetActive(true);
        controles = true;
    }

    public void VolverDeControles()
    {
        Panel_Principal.SetActive(true);
        Panel_Controles.SetActive(false);
        controles = false;
    }

    public void Desactivar_GrabPass()
    {
        GrabPass1.SetActive(false);
        GrabPass2.SetActive(false);
        GrabPass3.SetActive(false);
        GrabPass4.SetActive(false);
        Boton2GB.SetActive(true);
        Boton1GB.SetActive(false);
    }

    public void Activar_GrabPass()
    {
        GrabPass1.SetActive(true);
        GrabPass2.SetActive(true);
        GrabPass3.SetActive(true);
        GrabPass4.SetActive(true);
        Boton1GB.SetActive(true);
        Boton2GB.SetActive(false);
    }
}