using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject talkUI;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�Ӵ����˽�̨");
        talkUI.SetActive(true);
    }
}
