using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : ViewBase
{
    #region ����
    private List<Article> articles = new List<Article>();
    private List<GameObject> articleItems = new List<GameObject>();
    #endregion
    public GameObject articleItemPrefab;
    //public BagGrid[] bagGrids;
    private BagGrid[] bagGrids;
    public MenuPanel menuPanel;

    public BagGrid currentHoverGrid;//��ǰ�����ĸ���(��굱ǰָ��ĸ���)
    public ArticleItem currentDragArticle;//��ǰ�����ק������

    public static BagPanel _instance;//��BagPanel��Ϊ����ģʽ�������

    public ArticleInfomation articleInfomation;

    #region Unity�ص�
    private void Awake()
    {
        _instance = this;
        InitArticleData();
        bagGrids = transform.GetComponentsInChildren<BagGrid>();
    }
    private void Start()
    {
        LoadData();
    }
    #endregion

    #region ����
    public override void Hide()
    {
        base.Hide();
        menuPanel.Show();
    }//����BagPanel������ʾ������
    public override void Show()
    {
        //base.Show();
        Invoke("ShowExc", 1);
    }//����ʾ��ʱ���ӳ�һ�������ƥ�䶯������ʱ��
    public void ShowExc()
    {
        base.Show();
    }
    //��ʼ����Ʒ����
    public void InitArticleData()
    {
        //����
        articles.Add(new Article("ǹ", "Sprite/weapon1", ArticleType.Weapon, 1));
        articles.Add(new Article("��", "Sprite/weapon2", ArticleType.Weapon, 2));
        articles.Add(new Article("��", "Sprite/weapon3", ArticleType.Weapon, 3));
        articles.Add(new Article("�ɽ�", "Sprite/weapon4", ArticleType.Weapon, 4));
        //ҩƷ
        articles.Add(new Article("����", "Sprite/drug1", ArticleType.Drug, 1));
        articles.Add(new Article("����", "Sprite/drug2", ArticleType.Drug, 2));
        articles.Add(new Article("ҩ��", "Sprite/drug3", ArticleType.Drug, 3));
        articles.Add(new Article("�ɵ�", "Sprite/drug4", ArticleType.Drug, 4));
        //Ь��
        articles.Add(new Article("��Ь", "Sprite/shoe1", ArticleType.Shoes, 1));
        articles.Add(new Article("��Ь", "Sprite/shoe2", ArticleType.Shoes, 2));
        articles.Add(new Article("Ь", "Sprite/shoe3", ArticleType.Shoes, 3));
        articles.Add(new Article("ƤЬ", "Sprite/shoe4", ArticleType.Shoes, 4));
        //�ؼ�
        articles.Add(new Article("����ʮ����", "Sprite/book1", ArticleType.Book, 1));
        articles.Add(new Article("������", "Sprite/book2", ArticleType.Book, 2));
        articles.Add(new Article("��������", "Sprite/book3", ArticleType.Book, 3));
        articles.Add(new Article("��������", "Sprite/book4", ArticleType.Book, 4));
    }

    //��������(Ĭ�ϼ���ȫ������)
    public void LoadData()
    {
        HideAllArticleItems();//�ڼ���֮ǰ������һ�����и���
        for(int i = 0; i < articles.Count; i++)
        {
            //bagGrids[i].SetArticleItem(LoadArticleItem(articles[i]));//all����λ�ò���������ǻ�����Ҫ����һ���÷�
            GetBagGrid().SetArticleItem(LoadArticleItem(articles[i]));
        }
    }

    //���ض�Ӧ���͵�����
    public void LoadData(ArticleType articleType)
    {
        HideAllArticleItems();//�ڼ���֮ǰ������һ�����и���
        for (int i = 0; i < articles.Count; i++)
        {
            if (articles[i].articleType == articleType)
            {
                //bagGrids[i].SetArticleItem(LoadArticleItem(articles[i]));//����ֵ��ע����ǣ����ֱ��ʹ�������������ô�����������������Ʒ�ͻ�ֱ��ȡ��All�����е��±꣬��ÿһ�����������е���Ʒ�����Զ����ɵ���������ǰ���All���λ������
                GetBagGrid().SetArticleItem(LoadArticleItem(articles[i]));
            }
        }
    }

    //��ȡһ�����еĸ���
    public BagGrid GetBagGrid()
    {
        for(int i = 0; i < bagGrids.Length; i++)
        {
            if (bagGrids[i].ArticleItem == null)
            {
                return bagGrids[i];
            }
        }
        return null;
    }

    //����һ����Ʒ����������������غ����ظ�����,�Ӷ��ܹ���������ͬ������Ʒ
    public ArticleItem LoadArticleItem(Article article)
    {
        //GameObject obj = GameObject.Instantiate(articleItemPrefab);//����ÿ�μ��ض���ʵ����һ����Ϸ���岻̫�ã�����Ӧ����ʵ����֮������屣���������������ǿ�����ǰ����һ��list�����غõ���Ϸ���屣������,����ѡ����һ���·���GetArticle()����������
        GameObject obj = GetArticleItem();
        ArticleItem articleItem = obj.GetComponent<ArticleItem>();
        articleItem.SetArticle(article);
        return articleItem;
    }
    //��ȡһ����Ʒ
    public GameObject GetArticleItem()
    {
        for(int i = 0; i < articleItems.Count; i++)
        {
            if (articleItems[i].activeSelf == false)//���ȱ���һ�¼��ϣ����articleItemsû��ʹ�ã���ô��ֱ����ʾ����
            {
                articleItems[i].SetActive(true);
                return articleItems[i];
            }
        }
        return GameObject.Instantiate(articleItemPrefab);
    }
    //���� ����������Ʒ
    public void HideAllArticleItems()
    {
        for(int i = 0; i < bagGrids.Length; i++)
        {
            if (bagGrids[i].ArticleItem != null)
            {
                bagGrids[i].ClearGrid();
            }
        }
    }
    #endregion

    #region ����¼�
    public void OnAllToggleValueChange(bool v)
    {
        if (v) { LoadData(); }
    }
    public void OnWeaponToggleValueChange(bool v)
    {
        if (v) { LoadData(ArticleType.Weapon); }
    }
    public void OnShoesToggleValueChange(bool v)
    {
        if (v) { LoadData(ArticleType.Shoes); }
    }
    public void OnBookToggleValueChange(bool v)
    {
        if (v) { LoadData(ArticleType.Book); }
    }
    public void OnDrugToggleValueChange(bool v)
    {
        if (v) { LoadData(ArticleType.Drug); }
    }
    #endregion
}
