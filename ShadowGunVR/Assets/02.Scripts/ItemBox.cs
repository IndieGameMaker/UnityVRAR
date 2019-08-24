using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public void OnLookAt(bool isLooked)
    {
        MoveLookAt.isStopped = isLooked;
    }
}
