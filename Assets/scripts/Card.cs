using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public int id = 0;
    Image sp;//图片--->Sprite  精灵
    //第二步 列出图片资源
    public Sprite[] sprites = null;

    bool canClick = true;//点击开关
    public  bool isIndeck = false;

    //用来当做层级判断,处理遮挡关系
    //layerNum 越小,越在下面,越大,越在上面
    public int layerNum = 0;
    //记录遮挡该卡片的上层卡片数量
    public int overNum = 0;
    //记录该卡片下层的卡片以及数量
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
        //矩形碰撞原理
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
            Debug.Log("被" + overNum + "张卡片覆盖了");
            this.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        return true;
    }
    public void setID(int _id, int _layerNum)//形参:  _id 识别类型码, _layerNum层级关系码
    {
        point = transform.localPosition;
        this.id = _id;
        this.layerNum = _layerNum;
        //TODO  既然设置了不同的ID,更换对应的图片
        //第一步:需要找到Image组件
        //GetComponent 获取组件函数
        sp = this.GetComponent<Image>();
        sp.sprite = this.sprites[this.id]; //需要图片资源
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Deck.Instance.optCard)//不允许操作,点击无效
        {
            return;
        }
        if (!canClick)
        {
            return;
        }
        if (overNum > 0)
        {
            return;//该卡片上层有卡片覆盖
        }
        Debug.Log("卡片被点击:id = " + id);

        //TODO 移动卡片
        //移动到目的地,
        //第一个参数是目的地(父节点空间坐标)坐标
        //第二个参数是时间跨度
        float x = -365 + Deck.Instance.currentNum * 123;
        point = transform.localPosition;
        //卡槽添加卡片
        if (Deck.Instance.addCard(this))
        {
            canClick = false;
            isIndeck = true;
            //动作队列
            Sequence sq = DOTween.Sequence();
            //移动动作
            Tween tw = transform.DOLocalMove(new Vector3(x, -641, 0), 0.2f);
            sq.Append(tw);//加入队列
            sq.AppendCallback(() => {//函数动作  匿名函数
                //移动动画之后在进行消除,
                Deck.Instance.check();
                Deck.Instance.optCard = true;//允许操作下一张牌
            });
            sq.Play();//动作队列运行
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
