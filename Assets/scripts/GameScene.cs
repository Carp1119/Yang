using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public GameObject settingDlgPrefab = null;
    public Button settingBtn = null;

    public Button randBtn = null;
    // Start is called before the first frame update
    void Start()
    {
        AudioMgr.Instance().PlayBGM("BgMusic", this.gameObject);
        settingBtn.onClick.AddListener(onSettingBtn);

        randBtn.onClick.AddListener(onRandBtn);
    }

    // Update is called once per frame
    void onSettingBtn()
    {
        AudioMgr.Instance().PlaySound("ButtonClick", settingBtn.gameObject);
        GameObject settingDlg = Instantiate(this.settingDlgPrefab);
        settingDlg.transform.SetParent(this.transform);
        settingDlg.transform.localPosition = Vector3.zero;
    }

    void onRandBtn()
    {
        randBtn.interactable = false;//������ť ���ܵ��
        GameMap.instance.beginRand();
        Invoke("unLockEandBtn", 1);//1��֮�������ť
    }
    void unLockEandBtn()
    {
        randBtn.interactable = true;
    }
}
