using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //�ű�����(���ⵥ��,ȷ���ýű�Ψһ��)
    public static Deck Instance = null;
    public int currentNum;//��ǰ��Ƭ����
    public bool optCard = true;//��������

    //���濨�ۿ�Ƭ������
    int size = 7;//��������,7�ſ�Ƭ
    Card[] cards = null;
    int[] cardNumData = null;//��Ƭ����

    void Start()//��ʼ��
    {
        //�ű�������ֵ
        Deck.Instance = this;
        cards = new Card[size];
        cardNumData = new int[14];
    }

    public bool addCard(Card _card)//�β�  ����Ŀ�Ƭ
    {
        if (currentNum >= size)//��������,��������ӿ�Ƭ��
        {
            return false;
        }
        optCard = false;//���������
        cards[currentNum] = _card;
        cardNumData[_card.id]++;
        currentNum++;
        Debug.Log("��ӿ�Ƭ������!");

        return true;
    }

    public bool check()//�����û������
    {
        for (int i = 0; i < 14; i++)
        {
            if (cardNumData[i] >= 3)
            {
                //���۴���������ͬ��Ƭ
                //������Ӧ�Ŀ�Ƭ
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
                //���¿��� 
                this.updateCard();
                return true;
            }
        }
        return false;
    }
    void updateCard()//���¿��ۺ���
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
                        //TODO �ƶ�����
                        float x = -365 + i * 123;
                        cards[i].transform.DOLocalMove(new Vector3(x, -641, 0), 0.1f);
                        break;
                    }
                }
            }
        }
    }
}
