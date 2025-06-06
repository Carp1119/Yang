using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    public int id = 0;
    public Deck  deck=null;
    Image sp;//ͼƬ sprite
    public Sprite[] sprites = null;
    bool canClick = true;
    void Start()
    {
        //���ҽڵ㺯��
        //GameObject deckGo = GameObject.Find("Canvas/deck");//���۽ڵ�
        //deck = deckGo.GetComponent<Deck>();//���۽ڵ��ϻ�ȡ�ű�����
    }

    public void setID(int _id)//_id�β�
    {
        this.id = _id;
        //TODO ��Ȼ�����˲�ͬ��ID��������Ӧ��ͼƬ
        sp = this.GetComponent<Image>();
        sp.sprite = this.sprites[this.id];

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Deck.Instance.optCard)
        {
            return;
        }
        if (!canClick)
        {
            return;
        }
        Debug.Log("��Ƭ�����:id = " + id);

        //TODO �ƶ���Ƭ
        //�ƶ���Ŀ�ĵ�,
        //��һ��������Ŀ�ĵ�(���ڵ�ռ�����)����
        //�ڶ���������ʱ����
        float x = -365 + Deck.Instance.currentNum * 123;
        //������ӿ�Ƭ
        if (Deck.Instance.addCard(this))
        {
            Sequence sq = DOTween.Sequence();

            Tween tw = transform.DOLocalMove(new Vector3(x, -641, 0), 0.4f);
            sq.Append(tw);
            sq.AppendCallback(() => {
                //�ƶ�����֮���ڽ�������,
                Deck.Instance.check();
                Deck.Instance.optCard = true;//�������
            });
            sq.Play();//������������
        }
    }
}
