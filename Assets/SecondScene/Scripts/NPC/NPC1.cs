using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : NPCbase
{//小女孩，特殊之处在于心情坏了之后就不想与你交流,高兴了就会给你道具1
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
        //Debug.Log("对方现在很生气");
        canCommunicate = false;
    }
    
    public override void goodMood()
    {
        //Debug.Log("对方现在很开心");
        giveKey = true;
        //canCommunicate = true;
        //player.isGetItem1 = true;
    }
}
