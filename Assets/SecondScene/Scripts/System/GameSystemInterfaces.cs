using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemInterfaces : MonoBehaviour
{
    #region ����
    public GameObject gameSystem;
    private GameSystem obj;
    #endregion

    #region �ӿں���
    //������ĳЩ�����ɶ�������ʹ��E�Ĵ���
    public void PlusExtraChances(int i)
    {
        obj.ExtraChancesAttribute += i;
    }

    public int GetChancesNum()
    {
        return obj.ChancesLeftToPushEAttribute;
    }

    public void GameOver()
    {
        Debug.Log("interfaces gameover");
        obj.GameOver();
    }
    #endregion

    #region �ص�
    private void Awake()
    {
        //if (GameSystem.Instance == null)
        //{
        //    GameObject.Instantiate(gameSystem);
        //}
        obj = gameSystem.GetComponent<GameSystem>();
    }
    
    #endregion
}
