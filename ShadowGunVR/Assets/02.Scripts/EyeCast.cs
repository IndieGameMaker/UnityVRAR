﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Transform camTr;

    void Start()
    {
        camTr = GetComponent<Transform>();        
    }

    void Update()
    {
        ray = new Ray(camTr.position, camTr.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20.0f, Color.green);
        if (Physics.Raycast(ray, out hit, 20.0f, 1<<8))
        {
            hit.collider.gameObject.GetComponent<ItemBox>().OnLookAt(true);
        }
        else
        {
            hit.collider.gameObject.GetComponent<ItemBox>().OnLookAt(false);
        }
    }
}
