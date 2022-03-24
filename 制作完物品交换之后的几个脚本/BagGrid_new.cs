using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{//用于管理格子
    private ArticleItem articleItem;
    public ArticleItem ArticleItem { get { return articleItem; } }

    private Image bagImage;
    private Color defaultBagImageColor;//用于在拖拽物体到格子上方的时候改变格子颜色
    private void Awake()
    {
        bagImage = transform.GetComponent<Image>();
        defaultBagImageColor = bagImage.color;
    }

    //设置格子的数据
    public void SetArticleItem(ArticleItem articleItem)
    {
        this.articleItem = articleItem;
        //设置父物体
        this.articleItem.transform.SetParent(transform);
        //设置位置
        this.articleItem.transform.localPosition = Vector3.zero;
        //设置Scale
        this.articleItem.transform.localScale = Vector3.one;
        //设置width
        this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    //清空格子
    public void ClearGrid()
    {
        articleItem.gameObject.SetActive(false);
        articleItem.transform.SetParent(null);
        articleItem = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (BagPanel._instance.currentHoverGrid != null)//当前正在拖拽的物体不等于空才需要赋值，等于空说明当前鼠标没有拖拽物品
        {
            BagPanel._instance.currentHoverGrid = this;
            bagImage.color = Color.yellow;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BagPanel._instance.currentHoverGrid = null;
        bagImage.color = defaultBagImageColor;
    }


}
