using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{//���ű����ý���Ϊ���Ӹ���controller�������ֵ��״̬�����Ҹ�������һ���������ֵ��״̬���仯�����������ֵ״̬������ʵ��ϸ�ڷ���������Ե�controller����
    public ItemController ItemController;
    public NPCcontroller npcController;
    public GameSystem gameSystem;
    public ThirdPersonController player;
    private void Update()
    {
        if(npcController.npc1.giveKey == true)player.isGetItem1 = true;
        if(npcController.npc2.giveKey == true && npcController.npc1.giveKey == true) player.isGetItem2 = true;
        if (npcController.npc3.giveKey == true) player.isGetItem3 = true;
        if (player.isGetItem1 == true && player.isGetItem2 == true && player.isGetItem3 == true) 
            ItemController.missionItem.missionComplete = true;
    }
}
