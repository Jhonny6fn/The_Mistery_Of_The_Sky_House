using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public bool PrimerMaterial = true;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Proyectil")
        {
            if (PrimerMaterial == true)
            {
                rend.sharedMaterial = material[1];
                Destroy(col.gameObject);
                StartCoroutine("esFalso");
            }

            if (PrimerMaterial == false)
            {
                rend.sharedMaterial = material[0];
                Destroy(col.gameObject);
                StartCoroutine("esTrue");
            }
        }
    }

    public IEnumerator esFalso()
    {
        yield return new WaitForSeconds(0.1f);
        PrimerMaterial = false;
    }

    public IEnumerator esTrue()
    {
        yield return new WaitForSeconds(0.1f);
        PrimerMaterial = true;
    }
}