using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : NPCbase
{//���ף�����ֵ����ʱҲԸ����㽻��������֮�����ڱ���ҪNPC1���ڸ���״̬��ͬʱ��������ֵҲҪ���˲Ż�������3
    private void OnTriggerStay(Collider other)
    {
        checkPlayerWantToCommunicate();
    }
    private void OnTriggerExit(Collider other)
    {
        communicateUI.SetActive(false);
        refuseUI.SetActive(false);
    }
    public override void goodMood()
    {
        giveKey = true;
    }
}
