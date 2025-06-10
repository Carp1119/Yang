using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseDlg : MonoBehaviour
{
    public Button retryBtn = null;
    public Button tomenuBtn = null;

    public Image colorBg = null;
    public  Transform top=null;
    public  Transform mid = null;

    // Start is called before the first frame update
    void Start()
    {
        top.localPosition = new Vector3(-1000, 0, 0);
        top.DOLocalMove(Vector3.zero, 0.3f);

        mid.localPosition = new Vector3(1000, -40, 0);
        mid.DOLocalMove(new Vector3(0, -40, 0), 0.3f);

        retryBtn.transform.localPosition = new Vector3(-1000, -488, 0);
        retryBtn.transform.DOLocalMove(new Vector3(0, -488, 0), 0.3f);

        tomenuBtn.transform.localPosition = new Vector3(1000, -750, 0);
        tomenuBtn.transform.DOLocalMove(new Vector3(0, -750, 0), 0.3f);

        retryBtn.onClick.AddListener(onRetryBtn);
        tomenuBtn.onClick.AddListener(onToMenuBtn);

        //颜色透明度
        colorBg.color = new Color(0,0,0,0);
        colorBg.DOColor(new Color(0, 0, 0, 0.8f),0.3f);
        //RectTransform colorBg = this.transform.Find("colorBg").GetComponent<RectTransform>();
        //colorBg.sizeDelta = new Vector2(Screen.width, Screen.height);

        //按钮
        retryBtn.onClick.AddListener(onRetryBtn);
        tomenuBtn.onClick.AddListener(onToMenuBtn);

    }

    // Update is called once per frame
    void onRetryBtn()
    {
        SceneManager.LoadScene("lv_1_Scene");
    }
    void onToMenuBtn()
    {
        SceneManager.LoadScene("menuScene");
        
    }
}
