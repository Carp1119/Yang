using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public int id = 0;
    Image sp;//ͼƬ--->Sprite  ����
    //�ڶ��� �г�ͼƬ��Դ
    public Sprite[] sprites = null;

    bool canClick = true;//�������
    public  bool isIndeck = false;

    //���������㼶�ж�,�����ڵ���ϵ
    //layerNum ԽС,Խ������,Խ��,Խ������
    public int layerNum = 0;
    //��¼�ڵ��ÿ�Ƭ���ϲ㿨Ƭ����
    public int overNum = 0;
    //��¼�ÿ�Ƭ�²�Ŀ�Ƭ�Լ�����
    Card[] overCards = new Card[100];
    public int overCardsNum;

    public Vector3 point;
    

    void Start()
    {

    }

    public bool onCollid(Card _card)
    {
        if (this.layerNum == _card.layerNum)
        {
            return false;
        }
        //������ײԭ��
        float dx = Mathf.Abs(this.transform.position.x - _card.transform.position.x);
        float dy = Mathf.Abs(this.transform.position.y - _card.transform.position.y);
        float _w = 88;
        float _h = 98;
        if (dx > _w || dy > _h)
        {
            return false;
        }

        if (this.layerNum > _card.layerNum)
        {
            overCards[overCardsNum++] = _card;
        }
        else if (this.layerNum < _card.layerNum)
        {
            overNum++;
            Debug.Log("��" + overNum + "�ſ�Ƭ������");
            this.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        return true;
    }
    public void setID(int _id, int _layerNum)//�β�:  _id ʶ��������, _layerNum�㼶��ϵ��
    {
        point = transform.localPosition;
        this.id = _id;
        this.layerNum = _layerNum;
        //TODO  ��Ȼ�����˲�ͬ��ID,������Ӧ��ͼƬ
        //��һ��:��Ҫ�ҵ�Image���
        //GetComponent ��ȡ�������
        sp = this.GetComponent<Image>();
        sp.sprite = this.sprites[this.id]; //��ҪͼƬ��Դ
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Deck.Instance.optCard)//���������,�����Ч
        {
            return;
        }
        if (!canClick)
        {
            return;
        }
        if (overNum > 0)
        {
            return;//�ÿ�Ƭ�ϲ��п�Ƭ����
        }
        Debug.Log("��Ƭ�����:id = " + id);

        //TODO �ƶ���Ƭ
        //�ƶ���Ŀ�ĵ�,
        //��һ��������Ŀ�ĵ�(���ڵ�ռ�����)����
        //�ڶ���������ʱ����
        float x = -365 + Deck.Instance.currentNum * 123;
        point = transform.localPosition;
        //������ӿ�Ƭ
        if (Deck.Instance.addCard(this))
        {
            canClick = false;
            isIndeck = true;
            //��������
            Sequence sq = DOTween.Sequence();
            //�ƶ�����
            Tween tw = transform.DOLocalMove(new Vector3(x, -641, 0), 0.2f);
            sq.Append(tw);//�������
            sq.AppendCallback(() => {//��������  ��������
                //�ƶ�����֮���ڽ�������,
                Deck.Instance.check();
                Deck.Instance.optCard = true;//���������һ����
            });
            sq.Play();//������������
            for (int i = 0; i < overCardsNum; i++)
            {
                overCards[i].overNum--;
                if (overCards[i].overNum <= 0)
                {
                    overCards[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }
          

            
        }
    }


}
