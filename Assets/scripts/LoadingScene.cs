using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    //��Ϸ��ʼ��ť ����
    public Button gamestartBtn=null;
    // Start is called before the first frame update
    void Start()
    {
        //��ť�����Ӧ������������changeScene�ص�����
        gamestartBtn.onClick.AddListener(this.changeScene);
    }
    void changeScene()
    {
        //�л����������˵�����
        SceneManager.LoadScene("menuScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
