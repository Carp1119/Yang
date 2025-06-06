using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    //游戏开始按钮 变量
    public Button gamestartBtn=null;
    // Start is called before the first frame update
    void Start()
    {
        //按钮点击响应，监听，调用changeScene回调函数
        gamestartBtn.onClick.AddListener(this.changeScene);
    }
    void changeScene()
    {
        //切换场景到主菜单界面
        SceneManager.LoadScene("menuScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
