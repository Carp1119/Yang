using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //脚本单例(特殊单例,确保该脚本唯一性)
    public static Deck Instance = null;
    public int currentNum;//当前卡片数量
    public bool optCard = true;//操作开关

    //保存卡槽卡片的数组
    int size = 7;//卡槽容量,7张卡片
    Card[] cards = null;
    int[] cardNumData = null;//卡片数量

    void Start()//初始化
    {
        //脚本单例赋值
        Deck.Instance = this;
        cards = new Card[size];
        cardNumData = new int[14];
    }

    public bool addCard(Card _card)//形参  点击的卡片
    {
        if (currentNum >= size)//卡槽满了,不能再添加卡片了
        {
            return false;
        }
        optCard = false;//不允许操作
        cards[currentNum] = _card;
        cardNumData[_card.id]++;
        currentNum++;
        Debug.Log("添加卡片到卡槽!");

        return true;
    }

    public bool check()//检查有没有三消
    {
        for (int i = 0; i < 14; i++)
        {
            if (cardNumData[i] >= 3)
            {
                //卡槽存在三张相同卡片
                //消除对应的卡片
                for (int j = 0; j < currentNum; j++)
                {
                    if (cards[j] != null && cards[j].id == i)
                    {
                        GameObject.Destroy(cards[j].gameObject);
                        cards[j] = null;
                    }
                }
                currentNum -= 3;
                cardNumData[i] = 0;
                //更新卡槽 
                this.updateCard();
                return true;
            }
        }
        return false;
    }
    void updateCard()//更新卡槽函数
    {
        for (int i = 0; i < size; i++)
        {
            if (cards[i] == null)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (cards[j] != null)
                    {
                        cards[i] = cards[j];
                        cards[j] = null;
                        //TODO 移动动画
                        float x = -365 + i * 123;
                        cards[i].transform.DOLocalMove(new Vector3(x, -641, 0), 0.1f);
                        break;
                    }
                }
            }
        }
    }
}
