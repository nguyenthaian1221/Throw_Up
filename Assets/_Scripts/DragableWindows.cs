using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class DragableWindows : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {



    }

    //private void Update()
    //{
        //if (Input.GetMouseButtonDown(0) && SetPositionByClick())
        //{
        //    Debug.Log(Input.mousePosition);
        //    transform.position = Input.mousePosition;
        //}
    //}


    bool SetPositionByClick()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for (int i = 0; i < raycastResultList.Count; i++)
        {
            if (!raycastResultList[i].gameObject.CompareTag("PanelMinimap"))
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }


        return raycastResultList.Count > 0;

    }

  
}
