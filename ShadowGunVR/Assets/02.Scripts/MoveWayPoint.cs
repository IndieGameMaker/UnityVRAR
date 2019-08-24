using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWayPoint : MonoBehaviour
{
    private Transform tr;
    public float speed = 1.5f;
    public float damping = 1.0f;
    //웨이포인트를 저장할 배열
    public Transform[] points;
    public int nextIdx = 1;

    void Start()
    {
        tr = GetComponent<Transform>();
        GameObject wayPointGroupObj = GameObject.Find("WayPointGroup");
        if (wayPointGroupObj != null)
        {
            points = wayPointGroupObj.GetComponentsInChildren<Transform>();
        }
    }

    void Update()
    {
        //다음 웨이포인트를 향한 벡터 계산
        Vector3 dir = points[nextIdx].position - tr.position;
        //벡터의 각도(Quaternion 타입으로 산출)
        Quaternion rot = Quaternion.LookRotation(dir);
        //부드럽게 회전 - 보간함수
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        //이동처리
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}
