using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : NPCbase
{//СŮ��������֮���������黵��֮��Ͳ������㽻��,�����˾ͻ�������1
    private void OnTriggerStay(Collider other)
    {
        checkPlayerWantToCommunicate();
    }
    private void OnTriggerExit(Collider other)
    {
        communicateUI.SetActive(false);
        refuseUI.SetActive(false);
    }

    public override void badMood()
    {
        //Debug.Log("�Է����ں�����");
        canCommunicate = false;
    }
    
    public override void goodMood()
    {
        //Debug.Log("�Է����ںܿ���");
        giveKey = true;
        //canCommunicate = true;
        //player.isGetItem1 = true;
    }
}
