using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float fuerza;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerza);
    }

    void Update()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}