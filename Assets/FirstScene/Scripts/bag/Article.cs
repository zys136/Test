using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public enum ArticleType
{
    Weapon,
    Shoes,
    Book,
    Drug
}
public class Article
{
    public string name;
    public string spritePath;//����ͼƬ��·��
    public ArticleType articleType;
    public int count;

    public Article(string name,string spritePath,ArticleType articleType,int count)
    {
        this.name = name;
        this.spritePath = spritePath;
        this.articleType = articleType;
        this.count = count;
    }
    public virtual string GetArticleInfo()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("���ƣ�").Append(this.name).Append("\n");//��ôд���Խ�Լ�ڴ�
        //string name = "���ƣ�" + this.name;//��ôд�������ڴ�
        stringBuilder.Append("���ͣ�").Append(GetTypeName(this.articleType)).Append("\n");
        stringBuilder.Append("������").Append(this.count).Append("\n");

        return stringBuilder.ToString();
    }
    public string GetTypeName(ArticleType articleType)
    {
        switch (articleType)
        {
            case ArticleType.Weapon:
                return "����";
            case ArticleType.Shoes:
                return "Ь��";
            case ArticleType.Book:
                return "�ؼ�";
            case ArticleType.Drug:
                return "ҩƷ";
        }
        return "";
    }
}
