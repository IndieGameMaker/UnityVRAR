using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform controller;
    public LineRenderer laser;
    //레이의 거리
    public float range = 10.0f;

    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        laser.SetPosition(1, new Vector3(0, 0, range));
    }

    void Update()
    {
        //레이를 생성
        ray = new Ray(controller.position, controller.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            laser.SetPosition(1, new Vector3(0,0,hit.distance));
        }
        else
        {
            laser.SetPosition(1, new Vector3(0,0,range));
        }
    }
}
