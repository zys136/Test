using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : ViewBase
{
    #region 数据
    private List<Article> articles = new List<Article>();
    private List<GameObject> articleItems = new List<GameObject>();
    #endregion
    public GameObject articleItemPrefab;
    //public BagGrid[] bagGrids;
    private BagGrid[] bagGrids;
    public MenuPanel menuPanel;

    public BagGrid currentHoverGrid;//当前所处的格子(鼠标当前指向的格子)
    public ArticleItem currentDragArticle;//当前鼠标拖拽的物体

    public static BagPanel _instance;//将BagPanel作为单例模式方便调用

    public ArticleInfomation articleInfomation;

    #region Unity回调
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

    #region 方法
    public override void Hide()
    {
        base.Hide();
        menuPanel.Show();
    }//隐藏BagPanel并且显示主界面
    public override void Show()
    {
        //base.Show();
        Invoke("ShowExc", 1);
    }//让显示的时候延迟一秒出现以匹配动画出现时间
    public void ShowExc()
    {
        base.Show();
    }
    //初始化物品数据
    public void InitArticleData()
    {
        //武器
        articles.Add(new Article("枪", "Sprite/weapon1", ArticleType.Weapon, 1));
        articles.Add(new Article("刀", "Sprite/weapon2", ArticleType.Weapon, 2));
        articles.Add(new Article("剑", "Sprite/weapon3", ArticleType.Weapon, 3));
        articles.Add(new Article("仙剑", "Sprite/weapon4", ArticleType.Weapon, 4));
        //药品
        articles.Add(new Article("饺子", "Sprite/drug1", ArticleType.Drug, 1));
        articles.Add(new Article("鸡肉", "Sprite/drug2", ArticleType.Drug, 2));
        articles.Add(new Article("药丸", "Sprite/drug3", ArticleType.Drug, 3));
        articles.Add(new Article("仙丹", "Sprite/drug4", ArticleType.Drug, 4));
        //鞋子
        articles.Add(new Article("草鞋", "Sprite/shoe1", ArticleType.Shoes, 1));
        articles.Add(new Article("布鞋", "Sprite/shoe2", ArticleType.Shoes, 2));
        articles.Add(new Article("鞋", "Sprite/shoe3", ArticleType.Shoes, 3));
        articles.Add(new Article("皮鞋", "Sprite/shoe4", ArticleType.Shoes, 4));
        //秘籍
        articles.Add(new Article("降龙十八掌", "Sprite/book1", ArticleType.Book, 1));
        articles.Add(new Article("九阳神功", "Sprite/book2", ArticleType.Book, 2));
        articles.Add(new Article("如来神掌", "Sprite/book3", ArticleType.Book, 3));
        articles.Add(new Article("葵花宝典", "Sprite/book4", ArticleType.Book, 4));
    }

    //加载数据(默认加载全部数据)
    public void LoadData()
    {
        HideAllArticleItems();//在加载之前先清理一下所有格子
        for(int i = 0; i < articles.Count; i++)
        {
            //bagGrids[i].SetArticleItem(LoadArticleItem(articles[i]));//all里面位置不会出错，但是还是需要更改一下用法
            GetBagGrid().SetArticleItem(LoadArticleItem(articles[i]));
        }
    }

    //加载对应类型的数据
    public void LoadData(ArticleType articleType)
    {
        HideAllArticleItems();//在加载之前先清理一下所有格子
        for (int i = 0; i < articles.Count; i++)
        {
            if (articles[i].articleType == articleType)
            {
                //bagGrids[i].SetArticleItem(LoadArticleItem(articles[i]));//这里值得注意的是，如果直接使用这个方法，那么背包中其他种类的物品就会直接取得All类型中的下标，即每一个单独种类中的物品不会自动生成到最上面而是按照All里的位置排列
                GetBagGrid().SetArticleItem(LoadArticleItem(articles[i]));
            }
        }
    }

    //获取一个空闲的格子
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

    //加载一个物品，让上面的两个加载函数重复调用,从而能够加载所有同类型物品
    public ArticleItem LoadArticleItem(Article article)
    {
        //GameObject obj = GameObject.Instantiate(articleItemPrefab);//这里每次加载都会实例化一个游戏物体不太好，我们应该在实例化之后把物体保存起来，所以我们可以在前面用一个list将加载好的游戏物体保存起来,这里选择用一个新方法GetArticle()代替这个语句
        GameObject obj = GetArticleItem();
        ArticleItem articleItem = obj.GetComponent<ArticleItem>();
        articleItem.SetArticle(article);
        return articleItem;
    }
    //获取一个物品
    public GameObject GetArticleItem()
    {
        for(int i = 0; i < articleItems.Count; i++)
        {
            if (articleItems[i].activeSelf == false)//首先遍历一下集合，如果articleItems没有使用，那么就直接显示出来
            {
                articleItems[i].SetActive(true);
                return articleItems[i];
            }
        }
        return GameObject.Instantiate(articleItemPrefab);
    }
    //清理 隐藏所有物品
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

    #region 点击事件
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
