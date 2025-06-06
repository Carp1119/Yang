using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public Button joinBtn = null;
    // Start is called before the first frame update
    void Start()
    {
        joinBtn.onClick.AddListener(this.changeScene);
    }

    void changeScene()
    {
        SceneManager.LoadScene("lv_1_Scene");
    }
}
