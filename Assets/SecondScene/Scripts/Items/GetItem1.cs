using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem1 : ItemInfoBase
{
    public ThirdPersonController player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player" || player.CommunicateTrigger == true)
        {
            player.isGetItem1 = true;
        }
    }
}
