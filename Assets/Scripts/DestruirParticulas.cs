using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirParticulas : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 1.2f);
    }
}