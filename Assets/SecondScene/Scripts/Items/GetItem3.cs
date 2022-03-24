using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem3 : MonoBehaviour
{
    public ThirdPersonController player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" || player.CommunicateTrigger == true)
        {
            player.isGetItem3 = true;
        }
    }
}
