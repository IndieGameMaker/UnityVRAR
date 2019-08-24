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

}
