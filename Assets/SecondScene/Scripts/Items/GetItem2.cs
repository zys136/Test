using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem2 : MonoBehaviour
{
    public ThirdPersonController player;

    #region 获取条件
    public bool Check_bool ;
    public float Check_int;
    public float Check_float;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" || player.CommunicateTrigger == true)
        {
            player.isGetItem2 = true;
        }
    }
}
