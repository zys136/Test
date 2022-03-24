using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
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

        this.articleItem.gameObject.SetActive(true);
        //���ø�����
        this.articleItem.transform.SetParent(transform);
        //����λ��
        //this.articleItem.transform.localPosition = Vector3.zero;//����ᵼ��������ƶ�ֱ�ӵ����ĵ㣬����ϣ���ܻ����ƶ���Ŀ��ص�
        this.articleItem.MoveToOrigin(() =>
        {
            //���ÿ��
            this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
        });
        //����Scale
        this.articleItem.transform.localScale = Vector3.one;
        //����width    ��ǰ�����лᵼ��������ק���¸��ӵĹ�����ͣ����˸һ�£���Ϊ���������õ����⣬�������ǻ�һ�ַ�ʽ���Ƚ�������ע�͵���Ȼ��ŵ������Ǹ�MoveToOrigin�������棬���ƶ�֮�������ÿ��
        //this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        //this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    //��ո���
    public void ClearGrid()
    {
        articleItem.gameObject.SetActive(false);
        //articleItem.transform.SetParent(null);//Ϊ���������ƶ����¸��ӵĹ��̱Ƚϻ���˿��������ע�͵�
        articleItem = null;
    }

    public void DragToThisGrid(ArticleItem articleItem)
    {
        //�õ��ɸ���
        BagGrid lastGrid = articleItem.transform.parent.GetComponent<BagGrid>();
        //�ж��������������û����Ʒ
        if (this.articleItem == null)
        {
            //��վɸ���
            lastGrid.ClearGrid();
            //�����¸���
            SetArticleItem(articleItem);
        }
        else
        {//��ǰ��������Ʒ����Ҫ���н���
            lastGrid.SetArticleItem(this.articleItem);
            //�����¸���
            SetArticleItem(articleItem);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (BagPanel._instance.currentDragArticle != null)//��ǰ������ק�����岻���ڿղ���Ҫ��ֵ�����ڿ�˵����ǰ���û����ק��Ʒ
        {
            BagPanel._instance.currentHoverGrid = this;
            bagImage.color = Color.yellow;
        }

        if (this.articleItem != null)//����ǰ��������Ʒ��Ϊ�յ�ʱ��
        { //��ʾ��ǰ������Ʒ��Ϣ
            BagPanel._instance.articleInfomation.Show();
            BagPanel._instance.articleInfomation.SetShowInfo(this.articleItem.GetArticleInfo());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BagPanel._instance.currentHoverGrid = null;
        bagImage.color = defaultBagImageColor;

        //���ظ��ӵ���Ʒ��Ϣ
        BagPanel._instance.articleInfomation.Hide();
    }


}
