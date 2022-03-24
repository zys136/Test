using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
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

        this.articleItem.gameObject.SetActive(true);
        //设置父物体
        this.articleItem.transform.SetParent(transform);
        //设置位置
        //this.articleItem.transform.localPosition = Vector3.zero;//这里会导致物体的移动直接到中心点，我们希望能缓慢移动到目标地点
        this.articleItem.MoveToOrigin(() =>
        {
            //设置宽高
            this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
        });
        //设置Scale
        this.articleItem.transform.localScale = Vector3.one;
        //设置width    以前这两行会导致物体拖拽到新格子的过程中停顿闪烁一下，因为这两行设置的问题，所以我们换一种方式，先将这两行注释掉，然后放到上面那个MoveToOrigin函数里面，让移动之后再设置宽高
        //this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        //this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    //清空格子
    public void ClearGrid()
    {
        articleItem.gameObject.SetActive(false);
        //articleItem.transform.SetParent(null);//为了让物体移动到新格子的过程比较缓慢丝滑，所以注释掉
        articleItem = null;
    }

    public void DragToThisGrid(ArticleItem articleItem)
    {
        //得到旧格子
        BagGrid lastGrid = articleItem.transform.parent.GetComponent<BagGrid>();
        //判断这个格子里面有没有物品
        if (this.articleItem == null)
        {
            //清空旧格子
            lastGrid.ClearGrid();
            //设置新格子
            SetArticleItem(articleItem);
        }
        else
        {//当前格子有物品，则要进行交换
            lastGrid.SetArticleItem(this.articleItem);
            //设置新格子
            SetArticleItem(articleItem);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (BagPanel._instance.currentDragArticle != null)//当前正在拖拽的物体不等于空才需要赋值，等于空说明当前鼠标没有拖拽物品
        {
            BagPanel._instance.currentHoverGrid = this;
            bagImage.color = Color.yellow;
        }

        if (this.articleItem != null)//当当前格子内物品不为空的时候
        { //显示当前格子物品信息
            BagPanel._instance.articleInfomation.Show();
            BagPanel._instance.articleInfomation.SetShowInfo(this.articleItem.GetArticleInfo());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BagPanel._instance.currentHoverGrid = null;
        bagImage.color = defaultBagImageColor;

        //隐藏格子的物品信息
        BagPanel._instance.articleInfomation.Hide();
    }


}
