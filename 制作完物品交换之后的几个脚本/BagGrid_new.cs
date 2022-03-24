using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{//���ڹ������
    private ArticleItem articleItem;
    public ArticleItem ArticleItem { get { return articleItem; } }

    private Image bagImage;
    private Color defaultBagImageColor;//��������ק���嵽�����Ϸ���ʱ��ı������ɫ
    private void Awake()
    {
        bagImage = transform.GetComponent<Image>();
        defaultBagImageColor = bagImage.color;
    }

    //���ø��ӵ�����
    public void SetArticleItem(ArticleItem articleItem)
    {
        this.articleItem = articleItem;
        //���ø�����
        this.articleItem.transform.SetParent(transform);
        //����λ��
        this.articleItem.transform.localPosition = Vector3.zero;
        //����Scale
        this.articleItem.transform.localScale = Vector3.one;
        //����width
        this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    //��ո���
    public void ClearGrid()
    {
        articleItem.gameObject.SetActive(false);
        articleItem.transform.SetParent(null);
        articleItem = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (BagPanel._instance.currentHoverGrid != null)//��ǰ������ק�����岻���ڿղ���Ҫ��ֵ�����ڿ�˵����ǰ���û����ק��Ʒ
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
