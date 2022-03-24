using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbase : MonoBehaviour
{//��ɫ��Ҫ���Ʊ������������ֵ�Լ��Ի���ĳ������أ��Ի��Ľ�������ֹ�ȣ�ȫ�ֵ��ߵ��趨����controller
    public int moodLevel = 5;
    //public bool isAlive = true;
    public bool canCommunicate = true;
    public GameObject self;
    public ThirdPersonController player;
    public GameObject communicateUI;
    public GameObject refuseUI;
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
    public virtual void moodStatusCheck() 
    {
        if (moodLevel <= 0) badMood();
        else if(moodLevel >= 10)goodMood();
        else normalMood();
    }
    public virtual void goodMood(){ }
    public virtual void normalMood(){ }
    public virtual void badMood(){ }
}
