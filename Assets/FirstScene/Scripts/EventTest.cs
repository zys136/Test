using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EventTest : MonoBehaviour, IPointerUpHandler,
    //IPointerClickHandler, 
    //IPointerDownHandler,
    IBeginDragHandler,//��ק�¼�
    IEndDragHandler//������ק
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("��ʼ��ק");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("������ק");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("���̧��");
    }
    
}
