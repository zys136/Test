using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleItem : MonoBehaviour
{
    #region �ֶ�
    private Image articleSprite;
    private Text number;
    private Article article;

    private UIDrag uIDrag;
    private Canvas canvas;
    private int defaultSort;

    private Vector3 currentLocalPosition;
    private float moveOriginTimer;//��ʱ
    private float moveOriginTime=0.2f; //ʱ��
    private bool isMovingOrigin = false;
    private Action onMoveEnd;
    #endregion
    #region Unity�ص�
    private void Awake()
    {
        articleSprite = transform.GetComponent<Image>();
        number = transform.Find("Text").GetComponent<Text>();

        uIDrag = transform.GetComponent<UIDrag>();
        uIDrag.onStartDrag += this.OnStartDrag;
        uIDrag.onDrag += this.OnDrag;
        uIDrag.onEndDrag += this.OnEndDrag;

        canvas = transform.GetComponent<Canvas>();
        defaultSort = canvas.sortingOrder;
    }

    private void Update()
    {
        MovingOrigin();//��ԭ���ƶ�
    }
    #endregion

    #region ����
    public void SetArticle(Article article)
    {
        this.article = article;
        //��ʾ����
        articleSprite.sprite = Resources.Load<Sprite>(article.spritePath);
        number.text = article.count.ToString();
    }
    public void OnStartDrag()
    {
        canvas.sortingOrder = defaultSort + 1;
        BagPanel._instance.currentDragArticle = this;
    }
    public void OnDrag()
    {
        
    }

    public void OnEndDrag()
    {
        if(BagPanel._instance.currentHoverGrid != null)
        {//���뵽�����������
            BagPanel._instance.currentHoverGrid.DragToThisGrid(BagPanel._instance.currentDragArticle);
            //�ָ��㼶
            canvas.sortingOrder = defaultSort;
        }
        else
        {
         //������ק�ص�ԭ��
            MoveToOrigin(() =>
            {//�ָ��㼶
                canvas.sortingOrder = defaultSort;
            }
            );
        }


        BagPanel._instance.currentDragArticle = null;
    }

    //������ԭ���ƶ�
    public void MovingOrigin()
    {
        if (isMovingOrigin)
        {
            moveOriginTimer += Time.deltaTime * (1.0f / moveOriginTime);
            transform.localPosition = Vector3.Lerp(currentLocalPosition, Vector3.zero, moveOriginTimer);
            if (moveOriginTimer >= 1)
            {
                isMovingOrigin = false;
                if (onMoveEnd != null)
                {
                    onMoveEnd();
                }
            }
        }
    }
    public void MoveToOrigin(Action onMoveEnd)
    {
        isMovingOrigin = true;
        moveOriginTimer = 0.0f;
        currentLocalPosition = transform.localPosition;
        this.onMoveEnd = onMoveEnd;
    }
    
    public string GetArticleInfo()
    {
        return this.article.GetArticleInfo();
    }

    #endregion
}
