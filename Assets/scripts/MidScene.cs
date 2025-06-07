using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("changeScene",2);
    }

    // Update is called once per frame
    void changeScene()
    {
        SceneManager.LoadScene("lv_2_Scene");
    }
}
