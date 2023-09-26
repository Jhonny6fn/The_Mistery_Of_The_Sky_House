using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mezclar_Shaders : MonoBehaviour
{
    Material Mat;
    public GameObject Proyectil;
    private float Radius = 4.1f;

    void Start()
    {
        Mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Proyectil = GameObject.Find("Proyectil(Clone)");
        Mat.SetVector("_ProyectilPosition", Proyectil.transform.position);
        Mat.SetFloat("_Distance", Radius);
    }
}