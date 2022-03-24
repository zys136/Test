using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public GameObject eventObj;
    public GameObject infoText;
    public GameObject numText;
    //public Button btn1;
    public Button btn2;
    public Animator animator;
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);
        GameObject.DontDestroyOnLoad(this.numText);
        GameObject.DontDestroyOnLoad(this.infoText);
        //btn1.onClick.AddListener(LoadScene1);
        btn2.onClick.AddListener(LoadScene2);
       // btn3.onClick.AddListener(LoadScene3);
    }

    private void LoadScene1()
    {
        StartCoroutine(LoadSene(1));
        
    }

    private void LoadScene2()
    {
        StartCoroutine(LoadSene(2));
    }

    IEnumerator LoadSene(int index)//切换场景前会等待淡出动画结束，所以使用协程方法
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        
        yield return new WaitForSeconds(1);

        AsyncOperation async =  SceneManager.LoadSceneAsync(index);
        async.completed += OnloadScene;
    }

    private void OnloadScene(AsyncOperation obj)
    {

        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
