using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start ����");
        //��ʱ����2���ӵ��ú���changeScene
        Invoke("changeScene",2);
    }

    // Update is called once per frame
    void Update()//FPS
    {
       // Debug.Log("Update ���º���");
    }

    void changeScene()
    {
        //���� ������
        //�л�����
        SceneManager.LoadScene("loadingScene");
    }
}