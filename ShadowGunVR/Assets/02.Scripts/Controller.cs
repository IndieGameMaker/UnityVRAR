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
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger Button Click");
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch position x={0}, y={1}",pos.x, pos.y);
        }
    }
}
