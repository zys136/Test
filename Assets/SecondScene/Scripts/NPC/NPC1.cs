using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : NPCbase
{
    private void Update()
    {
        moodStatusCheck();
        if (moodLevel <= -20) //Die();
            canCommunicate = false;
    }
    private void OnTriggerStay(Collider other)
    {
        checkPlayerWantToCommunicate();
    }
    private void OnTriggerExit(Collider other)
    {
        communicateUI.SetActive(false);
        refuseUI.SetActive(false);
    }

    public void doChose1()
    {
        moodLevel += -5;
        Debug.Log(moodLevel);
    }
    public void doChose2()
    {
        moodLevel += 0;
        Debug.Log(moodLevel);
    }
    public void doChose3()
    {
        moodLevel += 5;
        Debug.Log(moodLevel);
    }
    public override void badMood()
    {
        Debug.Log("对方现在很生气");
        canCommunicate = false;
    }
    
    public override void goodMood()
    {
        Debug.Log("对方现在很开心");
        canCommunicate = true;
        //player.isGetItem1 = true;
    }
}
