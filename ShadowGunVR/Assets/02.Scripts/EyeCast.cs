using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeCast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Transform camTr;
    private Image crossHair;
    private Animator anim;

    void Start()
    {
        camTr = GetComponent<Transform>(); 
        crossHair = camTr.Find("Canvas/Image").GetComponent<Image>();       
        anim = crossHair.GetComponent<Animator>();
    }

    void Update()
    {
        ray = new Ray(camTr.position, camTr.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20.0f, Color.green);
        if (Physics.Raycast(ray, out hit, 20.0f,1<<8))
        {
            MoveLookAt.isStopped = true;
            anim.SetBool("IsLook", true);
        }
        else
        {
            MoveLookAt.isStopped = false;
            anim.SetBool("IsLook", false);
        }
    }
}
