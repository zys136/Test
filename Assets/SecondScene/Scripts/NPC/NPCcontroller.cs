using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{//���ű���Ҫ������ܸ���NPC�����ݣ��Ӷ����������Item�������Ƿ���
    public NPC1 npc1;
    public NPC2 npc2;
    public NPC3 npc3;
    //public ThirdPersonController player;
    void Update()
    {
        NPC1Controller();
        NPC2Controller();
        NPC3Controller();
    }
    public void NPC1Controller()
    {
        if (npc1.moodLevel <= 0) npc1.badMood();
        else if (npc1.moodLevel >= 20) npc1.goodMood();
    }
    public void NPC2Controller()
    {
        if (npc2.moodLevel <= -20) { npc2.badMood(); }
        else if (npc2.moodLevel >= 20) npc2.goodMood();
    }
    public void NPC3Controller()
    {
        if (npc3.moodLevel <= 0) npc3.badMood();
        else if (npc3.moodLevel >= 20 && npc1.moodLevel >= 20) npc3.goodMood();
    }
}
