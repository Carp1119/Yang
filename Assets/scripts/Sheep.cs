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
        transform.Rotate(0, 0, 0.1f);//Χ��z����ת
        //transform.GetChild(0);//��ȡ�ڼ����ӽڵ����ͨ������
        for(int i=0;i<transform .childCount;i++)
        {
            //�ӽڵ�͸��ڵ���ת�����෴
            //�������ڵ��������ת������ӽڵ㷽�������
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
