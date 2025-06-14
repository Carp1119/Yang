using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public GameObject settingDlgPrefab = null;
    public GameObject gamestartDlgPrefab = null;

    public Button joinBtn = null;
    public Button settingBtn = null;
    void Start()
    {
        AudioMgr.Instance().PlayBGM("MainMusic", this.gameObject);
        joinBtn.onClick.AddListener(this.changeScene);
        settingBtn.onClick.AddListener(onSettingBtn);
    }

    void changeScene()
    {
        
        GameObject gamestartDlg = Instantiate(this.gamestartDlgPrefab);
        gamestartDlg.transform.SetParent(this.transform);
        gamestartDlg.transform.localPosition = Vector3.zero;
    }

    void onSettingBtn()
    {
        //TODO ���� ���öԻ���
        AudioMgr.Instance().PlaySound("ButtonClick", settingBtn.gameObject);
        //����
        GameObject settingDlg = Instantiate(this.settingDlgPrefab);
        settingDlg.transform.SetParent(this.transform);
        settingDlg.transform.localPosition = Vector3.zero;
    }
}
