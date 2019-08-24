using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnLookAt(bool isLooked)
    {
        //MoveLookAt.isStopped = isLooked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveLookAt.isStopped = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MoveLookAt.isStopped = false;
    }
}
