using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCilindro : MonoBehaviour
{
    [SerializeField] private float rotatespeedy;
    [SerializeField] private float rotatesmoothvert;
    [SerializeField] private float rotatevertmin;
    [SerializeField] private float rotatevertmax;

    private float RotateVert, RotateVertCalculate, velocityver;

    private void Awake()
    {
        RotateVert = gameObject.transform.rotation.x;
        RotateVertCalculate = RotateVert;
    }

    private void FixedUpdate()
    {
        RotateVertCalculate -= Input.GetAxis("Vertical") * rotatespeedy * -1;
        RotateVertCalculate = Mathf.Clamp(RotateVertCalculate, rotatevertmin, rotatevertmax);
        RotateVert = Mathf.SmoothDamp(RotateVert, RotateVertCalculate, ref velocityver, rotatesmoothvert);
        RotateVert = Mathf.Clamp(RotateVert, rotatevertmin, rotatevertmax);
        transform.localRotation = Quaternion.Euler(RotateVert, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z);
    }
}