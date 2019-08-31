using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public Transform controller;
    public LineRenderer laser;
    public Transform pointerPrefab;

    //레이의 거리
    public float range = 10.0f;

    private Ray ray;
    private RaycastHit hit;
    private Transform pointer;

    void Start()
    {
        //포인터 생성
        pointer = Instantiate(pointerPrefab);
        //라인렌더러의 길이 설정
        laser.SetPosition(1, new Vector3(0, 0, range));
    }

    void Update()
    {
        //레이를 생성
        ray = new Ray(controller.position, controller.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            laser.SetPosition(1, new Vector3(0,0,hit.distance));
            pointer.position = hit.point;
            pointer.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            laser.SetPosition(1, new Vector3(0,0,range));
            pointer.position = controller.position + (controller.forward * range);
            pointer.LookAt(controller.position);
            //pointer.rotation = Quaternion.LookRotation(pointer.position - controller.position);
        }
    }
}
