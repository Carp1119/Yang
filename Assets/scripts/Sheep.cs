using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.1f);//围绕z轴旋转
        //transform.GetChild(0);//获取第几个子节点对象，通过索引
        for(int i=0;i<transform .childCount;i++)
        {
            //子节点和父节点旋转方向相反
            //抵消父节点带来的旋转，解决子节点方向的问题
            transform.GetChild(i).Rotate(0, 0, -0.1f);
            if (transform.GetChild(i).position.y>transform .position .y)
            {
                transform.GetChild(i).localScale = new Vector3(1, 1, 1);
            }
            else 
            {
                transform.GetChild(i).localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
