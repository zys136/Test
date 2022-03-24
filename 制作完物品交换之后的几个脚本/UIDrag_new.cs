using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIDrag : MonoBehaviour, IBeginDragHandler, ICanvasRaycastFilter, IEndDragHandler, IDragHandler
{
    private Vector3 mousePosition;
    private RectTransform rect;

    private bool isDraging = false;

    public Action onStartDrag;
    public Action onDrag;
    public Action onEndDrag;

    private void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        if (rect == null)
        {
            throw new System.Exception("ֻ����קUI����");
        }
    }
    private void Update()
    {
        if (isDraging)
        {
            rect.anchoredPosition += (Vector2)(Input.mousePosition - mousePosition);
            mousePosition = Input.mousePosition;
            if (onDrag != null) { onDrag(); }
        }

        if (Input.GetMouseButtonUp(0) && isDraging)
        {
            if (onEndDrag != null) { onEndDrag(); }
            isDraging = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = Input.mousePosition;
        if (onStartDrag != null) { onStartDrag(); }
        isDraging = true;
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)//
    {//return true �¼��ͻ��⣬return false�¼��Ͳ�����

        return !isDraging;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    //public void OnDrag(PointerEventData eventData)//��ʱ�����һ�����⣬�Ǿ������Ĳ㼶������ק����Ĳ㼶���ͻᵼ�¸��Ӽ��������¼���Ϊ������赲�޷���Ӧ���������ʹ�ò㼶��͸�ķ�ʽ�ᵼ��Ondrag������OnEndDrag���������޷�ʹ�ã�����Ҫ��ԭ�������������ƶ��ĺ�������Update����
    //{
    //    rect.anchoredPosition += (Vector2)(Input.mousePosition - mousePosition);
    //    mousePosition = Input.mousePosition;
    //    if (onDrag != null) { onDrag(); }
    //}
    //public void OnEndDrag(PointerEventData eventData)//��OnEndDrag�����ü������̧��ͬʱ������ק�������
    //{
    //if (onEndDrag != null) { onEndDrag(); }
    //isDraging = false;
    //}
}
