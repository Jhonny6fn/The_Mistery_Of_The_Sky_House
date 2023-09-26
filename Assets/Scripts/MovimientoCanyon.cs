using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCanyon : MonoBehaviour
{
    [SerializeField] private float rotatespeedy;
    [SerializeField] private float rotatesmoothvert;
    private float RotateVert, RotateVertCalculate, velocityver;
    private float rotation = 90;

    public GameObject Proyectil;
    public Transform PosicionDisparo;
    private float nextFire;
    public float CoolDown;
    public CameraShake cameraShake;
    public ParticleSystem Particula;
    public AudioSource Shoot;

    public GameObject Camara1, Camara2;

    void Update()
    {
        RotateVertCalculate += Input.GetAxis("Horizontal") * rotatespeedy;
        RotateVert = Mathf.SmoothDamp(RotateVert, RotateVertCalculate, ref velocityver, rotatesmoothvert);
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + RotateVert, transform.rotation.z);
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + CoolDown;
            Instantiate(Proyectil, PosicionDisparo.transform.position, PosicionDisparo.transform.rotation);
            Instantiate(Particula, PosicionDisparo.transform.position, transform.rotation);
            Shoot.Play();
            StartCoroutine(cameraShake.Shake(0.1f, 0.15f));
        }

        if (Input.GetMouseButton(1))
        {
            Camara1.SetActive(false);
            Camara2.SetActive(true);
        }
        else
        {
            Camara1.SetActive(true);
            Camara2.SetActive(false);
        }
    }
}