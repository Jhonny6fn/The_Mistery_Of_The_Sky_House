using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efecto_PostProcesado : MonoBehaviour
{
    public Material efecto;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, efecto);
    }
}