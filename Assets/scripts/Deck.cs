using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //ʧ�ܵ�����Ԥ����
    public GameObject loseDlgPrefab = null;
    public GameObject winDlgPrefab = null;

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
                        GameMap.instance.deleteCard(cards[j].layerNum);
                        

                        cards[j] = null;
                    }
                }
                currentNum -= 3;
                cardNumData[i] = 0;
                GameMap.instance.totalNum -= 3;
                if(GameMap.instance.totalNum<=0)
                {
                    Debug.Log("���п�Ƭ�������");
                    
                    if(GameMap .instance.level==1)
                    {
                        //TODO�л�����ȥ���� ��һ��
                        SceneManager.LoadScene("midScene");
                    }else if(GameMap .instance .level==2)
                    {
                        //ʤ���������ڶ���
                        GameObject winDlg = Instantiate(this.winDlgPrefab);
                        winDlg.transform.SetParent(this.transform.parent);
                        winDlg.transform.localPosition = Vector3.zero;

                    }


                }
                else
                {
                    //���¿���
                    this.updateCard();
                }
                //���¿��� 
                this.updateCard();
                return true;
            }
        }
        if(currentNum>=7)//��������
        {
            //��Ϸ����ʧ��
            GameObject loseDlg = Instantiate(this.loseDlgPrefab);
            loseDlg.transform.SetParent(this.transform.parent);
            loseDlg.transform.localPosition = Vector3.zero;
             

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
