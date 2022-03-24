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
            throw new System.Exception("只能拖拽UI物体");
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
    {//return true 事件就会检测，return false事件就不会检测

        return !isDraging;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    //public void OnDrag(PointerEventData eventData)//此时会出现一个问题，那就是鼠标的层级低于拖拽物体的层级，就会导致格子监听鼠标的事件因为物体的阻挡无法响应，但是如果使用层级渗透的方式会导致Ondrag函数和OnEndDrag函数本身无法使用，所以要将原本物体跟随鼠标移动的函数做到Update里面
    //{
    //    rect.anchoredPosition += (Vector2)(Input.mousePosition - mousePosition);
    //    mousePosition = Input.mousePosition;
    //    if (onDrag != null) { onDrag(); }
    //}
    //public void OnEndDrag(PointerEventData eventData)//将OnEndDrag函数用监听鼠标抬起同时正在拖拽物体代替
    //{
    //if (onEndDrag != null) { onEndDrag(); }
    //isDraging = false;
    //}
}
