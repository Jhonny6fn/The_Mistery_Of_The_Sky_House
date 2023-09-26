using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana2_Shader : MonoBehaviour
{
    Material UnlitShaderMat;
    public float Tiempo = -0.5f;
    public bool funcion = true;
    public bool superado = true;
    public bool colision;
    public GameObject Diana;
    
    void Start()
    {
        UnlitShaderMat = GetComponent<Renderer>().material;
        colision = false;
    }
    
    void Update()
    {
        if (colision)
        {
            if (superado)
            {
                if (funcion)
                {
                    Tiempo += Time.deltaTime / 2;
                    if (Tiempo >= 0.55)
                    {
                        funcion = false;
                    }
                }
                else
                {
                    Tiempo -= Time.deltaTime / 2;
                    if (Tiempo <= -0.55)
                    {
                        funcion = true;
                        superado = false;
                    }
                }
                UnlitShaderMat.SetFloat("Tiempo", Tiempo);
            }
            else
            {
                superado = true;
                Tiempo = -0.5f;
                Diana.SetActive(true);
                colision = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Proyectil")
        {
            colision = true;
        }
    }
}