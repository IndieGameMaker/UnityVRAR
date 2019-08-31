using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //이동타입
    public enum MoveType
    {
         TOUCH_PAD
        ,TELEPORT
    }

    public MoveType moveType = MoveType.TELEPORT;

    public Transform camTr;
    public Transform gearController;

    private Ray ray;
    private RaycastHit hit;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();    
    }

    void Update()
    {
        //트리거 버튼 클릭 여부
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger Button Click");
        }

        //터치패드 터치 여부
        if (moveType == MoveType.TOUCH_PAD 
            && OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            //터치패드의 좌표값
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch position x={0}, y={1}",pos.x, pos.y);
            if (pos.y >= 0.2f)
            {
                cc.SimpleMove(camTr.forward * 2.0f);
            }
            if (pos.y <= -0.2f)
            {
                cc.SimpleMove(-camTr.forward * 2.0f);
            }
        }

        //텔레포트 버튼(버튼 릴리스)
        if (moveType == MoveType.TELEPORT
            && OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            ray = new Ray(gearController.position, gearController.forward);
            
            if (Physics.Raycast(ray, out hit, 20.0f, 1<<10))
            {
                Debug.Log("hit=" + hit.point);
                transform.position = hit.point;
            }
        }
    }
}
