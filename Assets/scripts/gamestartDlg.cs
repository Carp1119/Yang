using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamestartDlg : MonoBehaviour
{
    public Button gamestartBtn = null;
    public GameObject dlgBg = null;

    public Transform sheeps = null;
    // Start is called before the first frame update
    void Start()
    {
        gamestartBtn.onClick.AddListener(onGamestartBtn);
    }

    // Update is called once per frame
   void onGamestartBtn()
    {
        dlgBg.SetActive(false);
        Sequence sq = DOTween.Sequence();
        Tween tw = sheeps.DOLocalMove(new Vector3(-2500, 0, 0), 1.8f);
        sq.Append(tw);
        sq.AppendCallback(() =>{
            SceneManager.LoadScene("lv_1_Scene");
        });
        sq.Play();
    }
}
