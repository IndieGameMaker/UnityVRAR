using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //트리거 버튼 클릭 여부
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger Button Click");
        }
        //터치패드 터치 여부
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            //터치패드의 좌표값
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch position x={0}, y={1}",pos.x, pos.y);
        }
    }
}
