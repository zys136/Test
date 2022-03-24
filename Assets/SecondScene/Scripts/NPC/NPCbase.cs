using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbase : MonoBehaviour
{//��ɫ��Ҫ���Ʊ������������ֵ�Լ��Ի���ĳ������أ��Ի��Ľ�������ֹ�ȣ�ȫ�ֵ��ߵ��趨����controller
    public int moodLevel = 10;
    //public bool isAlive = true;
    public bool canCommunicate = true;
    public GameObject self;
    public ThirdPersonController player;
    public GameObject communicateUI;
    public GameObject refuseUI;
    public bool giveKey = false;
    public void checkPlayerWantToCommunicate()
    {
        if(player.CommunicateTrigger == true && canCommunicate == true )
        {
            communicateUI.SetActive(true);
        }
        else if(canCommunicate == false)
        {
            refuseUI.SetActive(true);
            communicateUI.SetActive(false);
        }
    }
    public virtual void Die()
    {
        self.SetActive(false);
    }

    public virtual void goodMood(){ }
    public virtual void normalMood(){ }
    public virtual void badMood(){ }
    public void moodLevelChange(int num)
    {
        moodLevel += num;
        Debug.Log(moodLevel);
    }
    public void moodLevelPlus()
    {
        this.moodLevel += 5;
        Debug.Log(moodLevel);
    }
    public void moodLevelStay()
    {
        this.moodLevel += 0;
        Debug.Log(moodLevel);
    }
    public void moodLevelMinus()
    {
        this.moodLevel += -5;
        Debug.Log(moodLevel);
    }
}
