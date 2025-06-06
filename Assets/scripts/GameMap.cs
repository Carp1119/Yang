using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    //卡片预制体资源变量
    public GameObject cardPrefab = null;

    int[] data = new int[27];

    void Start()//初始化
    {
        //本地坐标归零(画布中心)
        transform.localPosition = Vector3.zero;
        this.initData();//初始化数据

        this.createCards();//创建卡片
    }

    void initData()
    {
        //按顺序初始化
        for (int i = 0, n = 0; i < 3; i++)//3种id
        {
            for (int j = 0; j < 9; j++)//重复九次
            {
                this.data[n++] = i;
            }
        }
        int leng = this.data.Length;
        //随机打乱这个数组 洗牌函数
        for(int i=0;i<leng;i++)
        {
            int index = Random.Range(0, leng - i);
            //两个数交换
            //leng-1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
        
    }
    void createCards()//创建卡片
    {
        for (int i = 0, n = 0; i < 3; i++)//3层  3  3
        {
            for (int j = 0; j < 3; j++)//行 -- y
            {
                for (int k = 0; k < 3; k++)//列  --x
                {
                    //第二步: 需要从预制体创建一个新的节点(物体)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //第三步:需要调整层级关系,将新创建的物体,设置到地图上
                    //卡片节点设置父亲节点为当前地图节点
                    cardGo.transform.SetParent(this.transform);
                    //第四步:调整节点的坐标 位置
                    //设置在地图的原点位置
                    float x = -200 + k * 200;
                    float y = j * 200 + i * 10;
                    cardGo.transform.localPosition = new Vector3(x,y,0);
                    //获取卡片组件
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n++]);
                }
            }
        }
    }
}