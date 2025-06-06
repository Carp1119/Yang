using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start 启动");
        //定时器：2秒钟调用函数changeScene
        Invoke("changeScene",2);
    }

    // Update is called once per frame
    void Update()//FPS
    {
       // Debug.Log("Update 更新函数");
    }

    void changeScene()
    {
        //语句块 函数体
        //切换场景
        SceneManager.LoadScene("loadingScene");
    }
}