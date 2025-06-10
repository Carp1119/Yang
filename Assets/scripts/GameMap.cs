using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public static GameMap instance=null;

   
    //卡片预制体资源变量
    public GameObject cardPrefab = null;

    public int level = 1;//默认值 在界面上配置
    public int totalNum = 27;//默认值 在界面上配置

    int[] data = null;//数据
    Card[] cards = null;//关卡所有卡片

    void Start()//初始化
    {
        DOTween.SetTweensCapacity(3000, 200);
        GameMap.instance = this;
        //本地坐标归零(画布中心)
        transform.localPosition = Vector3.zero;
        data = new int[totalNum];//数据
        cards = new Card[totalNum];//关卡所有卡片
        switch(level)
            {
            case 1:
                {

                this.initData_1();//初始化数据
                this.createCards_1();//创建卡片
            }
                break;
            case 2:
                {
                    this.initData_2();//初始化数据
                    this.createCards_2();//创建卡片

                }
                break;
        }

       
    }

    void initData_1()
    {
        //按顺序初始化
        for (int i = 0, n = 0; i < 3; i++)//3种ID
        {
            for (int j = 0; j < 9; j++)//重复9次
            {
                this.data[n++] = i;
            }
        }
        //随机打乱这个数组  洗牌算法
        int leng = this.data.Length;
        for (int i = 0; i < leng; i++)
        {
            int index = Random.Range(0, leng - i);
            //两个数交换
            //leng - 1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
    }
    void createCards_1()//创建卡片
    {
        int n = 0;
        for (int i = 0; i < 3; i++)//3层 
        {
            for (int j = 0; j < 3; j++)//3行 -- y
            {
                for (int k = 0; k < 3; k++)//3列  --x
                {
                    //第二步: 需要从预制体创建一个新的节点(物体)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //第三步:需要调整层级关系,将新创建的物体,设置到地图上
                    //卡片节点设置父亲节点为当前地图节点
                    cardGo.transform.SetParent(this.transform);
                    //第四步:调整节点的坐标 位置
                    //设置在地图的原点位置
                    float x = -200 + k * 200+i*10;
                    float y = j * 200 + i * 25;
                    cardGo.transform.localPosition = new Vector3(x, y, 0);
                    //获取卡片组件
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n], n);
                    cards[n] = _card;
                    n++;
                }
            }
        }
            //遮挡关系
        for (int i = 0; i < totalNum; i++)
        {
            for (int j = 0; j < totalNum; j++)
            {
                cards[i].onCollid(cards[j]);//碰撞检测
            }
        }

    }

    void initData_2()
    {
        for (int i = 0,n=0; i < 14; i++)
        {
            for (int j = 0; j < 39; j++)
            {
                this.data[n++] = i;
            }
        }
        //随机打乱这个数组  洗牌算法
        int leng = this.data.Length;
        for (int i = 0; i < leng; i++)
        {
            int index = Random.Range(0, leng - i);
            //两个数交换
            //leng - 1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
    }
    void createCards_2()
    {
        int n = 0;//计数开始
        //左边一列40
        for (int i = 0; i < 40; i++)//
        {
            //第二步: 需要从预制体创建一个新的节点(物体)
            GameObject cardGo = Instantiate(cardPrefab);
            //第三步:需要调整层级关系,将新创建的物体,设置到地图上
            //卡片节点设置父亲节点为当前地图节点
            cardGo.transform.SetParent(this.transform);
            //第四步:调整节点的坐标 位置
            //设置在地图的原点位置
            float x = -466;
            float y = 625-i*10;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //获取卡片组件
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //右边一列40
        for (int i = 0; i < 40; i++)//
        {
            //第二步: 需要从预制体创建一个新的节点(物体)
            GameObject cardGo = Instantiate(cardPrefab);
            //第三步:需要调整层级关系,将新创建的物体,设置到地图上
            //卡片节点设置父亲节点为当前地图节点
            cardGo.transform.SetParent(this.transform);
            //第四步:调整节点的坐标 位置
            //设置在地图的原点位置
            float x = 466;
            float y = 40 + i * 10;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //获取卡片组件
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //左边一行37
        for(int i=0;i<37;i++)
        {
            //第二步: 需要从预制体创建一个新的节点(物体)
            GameObject cardGo = Instantiate(cardPrefab);
            //第三步:需要调整层级关系,将新创建的物体,设置到地图上
            //卡片节点设置父亲节点为当前地图节点
            cardGo.transform.SetParent(this.transform);
            //第四步:调整节点的坐标 位置
            //设置在地图的原点位置
            float x = -110-i*10;//-往左偏移
            float y = -265;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //获取卡片组件
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //右边一行37
        for (int i = 0; i < 37; i++)
        {
            //第二步: 需要从预制体创建一个新的节点(物体)
            GameObject cardGo = Instantiate(cardPrefab);
            //第三步:需要调整层级关系,将新创建的物体,设置到地图上
            //卡片节点设置父亲节点为当前地图节点
            cardGo.transform.SetParent(this.transform);
            //第四步:调整节点的坐标 位置
            //设置在地图的原点位置
            float x = 110 +i * 10;//-往右偏移
            float y = -265;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //获取卡片组件
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //中心部分 7行7列 8层
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)// -- y
            {
                for (int k = 0; k < 7; k++)//  --x
                {
                    //第二步: 需要从预制体创建一个新的节点(物体)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //第三步:需要调整层级关系,将新创建的物体,设置到地图上
                    //卡片节点设置父亲节点为当前地图节点
                    cardGo.transform.SetParent(this.transform);
                    //第四步:调整节点的坐标 位置
                    //设置在地图的原点位置
                    float x = -270 + k * 90;
                    float y = j*100;
                    if (j <3)
                    {
                        y -= 10;
                        y -= i * 8;
                    }
                    else if(j>3)
                    {
                        y+= 10;
                        y += i * 8;
                    }
                    if(k<3)
                    {
                        x -= 10;
                        x -= i * 8;
                    }else if(k>3)
                    {
                        x += 10;
                        x += i * 8;
                    }
                    cardGo.transform.localPosition = new Vector3(x, y, 0);
                    //获取卡片组件
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n], n);
                    cards[n] = _card;
                    n++;
                }
            }
        }

        //遮挡关系计算
        for (int i = 0; i < totalNum; i++)
        {
            for (int j = 0; j < totalNum; j++)
            {
                cards[i].onCollid(cards[j]);//碰撞检测
            }
        }
    }
 
    public void beginRand()
    {
        int leng = cards.Length;
        Sequence sq = DOTween.Sequence();

        for (int i = 0; i < leng; i++)
        {
            if (cards[i] != null && !cards[i].isIndeck)
            {
                cards[i].point = cards[i].transform.localPosition;//记录原位置
                //同时移动到中心点
                Tween tw1 = cards[i].transform.DOLocalMove(Vector3.zero, 0.15f).SetAutoKill(true);
                sq.Join(tw1);//Append串行,一个接一个按顺序执行  Join并行, 同时执行

            }
        }
        sq.AppendInterval(0.15f);
        sq.AppendCallback(randCards);
        for (int i = 0; i < leng; i++)
        {
            if (cards[i] != null && !cards[i].isIndeck)
            {
                //各自回到原位置
                Tween tw2 = cards[i].transform.DOLocalMove(cards[i].point, 0.15f).SetAutoKill(true);
                sq.Join(tw2);
            }
        }
        sq.SetAutoKill(true);
    }

    public void randCards()
    {
        int leng = cards.Length;
        int[] tempData = new int[totalNum - Deck.Instance.currentNum];
        for (int i = 0, n = 0; i < leng; i++)
        {
            if (cards[i] != null && !cards[i].isIndeck)
            {
                tempData[n++] = cards[i].id;
            }
        }
        leng = tempData.Length;
        //随机打乱这个数组  洗牌算法
        for (int i = 0; i < leng; i++)
        {
            int index = Random.Range(0, leng - i);
            //两个数交换
            //leng - 1
            int temp = tempData[index];
            tempData[index] = tempData[leng - 1 - i];
            tempData[leng - 1 - i] = temp;
        }
        leng = cards.Length;
        for (int i = 0, n = 0; i < leng; i++)
        {
            if (cards[i] != null && !cards[i].isIndeck)
            {
                cards[i].setID(tempData[n++], cards[i].layerNum);
            }
        }
    }

    public void deleteCard(int index)
    {
        GameObject.Destroy(cards[index].gameObject);
        cards[index] = null;
        data[index] = -1;
    }
}
