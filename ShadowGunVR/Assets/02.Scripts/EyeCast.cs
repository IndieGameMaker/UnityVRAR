using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EyeCast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Transform camTr;
    private Image crossHair;
    private Animator anim;

    private GameObject currButton;
    private GameObject prevButton;

    public float selectedTime = 1.0f;
    private float passedTime  = 0.0f;
    private Image circleBar;

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

        if (Physics.Raycast(ray, out hit, 20.0f,1<<8 | 1<<9))
        {
            MoveLookAt.isStopped = true;
            anim.SetBool("IsLook", true);
            GazeButton();
        }
        else
        {
            MoveLookAt.isStopped = false;
            anim.SetBool("IsLook", false);
            ReleaseButton();
        }
    }

    void GazeButton()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (hit.collider.gameObject.layer == 9)
        {
            //현재 응시하고 있는 버튼 객체를 저장
            currButton = hit.collider.gameObject;
            circleBar  = currButton.GetComponentsInChildren<Image>()[1];

            //새로운 버튼을 응시한 경우
            if (currButton != prevButton)
            {
                //현재 버튼에 PointerEnter Event
                ExecuteEvents.Execute(currButton, data, ExecuteEvents.pointerEnterHandler);
                //이전 버튼에 PointerExit Event
                ExecuteEvents.Execute(prevButton, data, ExecuteEvents.pointerExitHandler);
                prevButton = currButton;
            }
            else
            {
                passedTime += Time.deltaTime;
                circleBar.fillAmount = passedTime / selectedTime;
            }
        }
    }

    void ReleaseButton()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        
        if (prevButton != null)
        {
            ExecuteEvents.Execute(prevButton, data, ExecuteEvents.pointerExitHandler);
            prevButton = null;
        }
    }
}
