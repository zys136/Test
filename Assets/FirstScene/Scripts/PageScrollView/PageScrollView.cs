using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageScrollView : MonoBehaviour
{
    # region 字段
    ScrollRect rect;
    private int pageCount;
    private RectTransform content;
    private float[] pages;
    public float moveTime = 0.3f;
    private float timer = 0;
    private float startMovePos;
    private int currentIndex = 0;

    private bool isMoving = false;
    //是否开启自动滚动
    public bool isAutoScroll;
    #endregion
    #region Unity回调
    void Start()
    {
        //isMoving = false;
        rect = transform.GetComponent<ScrollRect>();
        if (rect == null)
        {
            throw new System.Exception("未查询到ScrollRect！");
        }
        content = transform.Find("Viewport/Content").GetComponent<RectTransform>();
        pageCount = content.childCount;
        pages = new float[pageCount];
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i] = i * (1.0f / (float)(pageCount - 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        ListenerMove();

    }
    public void ListenerMove()
    {
            timer += Time.deltaTime * (1 / moveTime);
            rect.horizontalNormalizedPosition = Mathf.Lerp(startMovePos, pages[currentIndex], timer);
            //(A,B,t)做差值运算从A移动到B，差值为t
            if (timer >= 1)
            {
                isMoving = false;
            }
        
    }
    public void ScrollToPage(int page)
    {
        isMoving = true;
        this.currentIndex = page;
        timer = 0;
        startMovePos = rect.horizontalNormalizedPosition;

    }
    #endregion

}
