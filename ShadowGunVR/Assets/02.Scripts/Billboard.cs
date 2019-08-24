using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;
    
    void Start()
    {
        camTr = Camera.main.transform;
        tr    = transform;    
    }

    void LateUpdate()
    {
        tr.LookAt(camTr.position);
    }
}
