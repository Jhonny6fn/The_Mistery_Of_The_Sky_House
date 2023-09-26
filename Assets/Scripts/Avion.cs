using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Sitio1")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }

        if (col.tag == "Sitio2")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
}