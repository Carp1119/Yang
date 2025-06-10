using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinDlg : MonoBehaviour
{
    public Button toMenuBtn = null;
    // Start is called before the first frame update
    void Start()
    {
        toMenuBtn.onClick.AddListener(onToMenu);
    }

    // Update is called once per frame
    void onToMenu()
    {
        SceneManager.LoadScene("menuScene");
    }
}
