using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDlg : MonoBehaviour
{
    public Button okBtn = null;
    public Slider bgmSlider = null;
    public Slider soundSlider = null;
    // Start is called before the first frame update
    void Start()
    {
        okBtn.onClick.AddListener(onOkBtn);

        bgmSlider.onValueChanged.AddListener(onBgmSlider);
        bgmSlider.value = AudioMgr.Instance().get_BGM_Volume();

        soundSlider.onValueChanged.AddListener(onSoundSlider);
        soundSlider.value =AudioMgr.Instance().get_Sound_Volume();

        RectTransform colorBg = this.transform.Find("colorBg").GetComponent<RectTransform>();
        colorBg.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
  void onOkBtn()
    {
        AudioMgr.Instance().PlaySound("ButtonClick", okBtn.gameObject);
        GameObject.Destroy(this.gameObject, 0.1f);
    }
    void onBgmSlider(float value)
    {
       
        AudioMgr.Instance().set_BGM_Volume(value);
    }
    void onSoundSlider(float value)
    {
        
        AudioMgr.Instance().set_Sound_Volume(value);
    }
}
