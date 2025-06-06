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
    Image sp;//图片 sprite
    public Sprite[] sprites = null;
    bool canClick = true;
    void Start()
    {
        //查找节点函数
        //GameObject deckGo = GameObject.Find("Canvas/deck");//卡槽节点
        //deck = deckGo.GetComponent<Deck>();//卡槽节点上获取脚本对象
    }

    public void setID(int _id)//_id形参
    {
        this.id = _id;
        //TODO 既然设置了不同的ID，更换对应的图片
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
        Debug.Log("卡片被点击:id = " + id);

        //TODO 移动卡片
        //移动到目的地,
        //第一个参数是目的地(父节点空间坐标)坐标
        //第二个参数是时间跨度
        float x = -365 + Deck.Instance.currentNum * 123;
        //卡槽添加卡片
        if (Deck.Instance.addCard(this))
        {
            Sequence sq = DOTween.Sequence();

            Tween tw = transform.DOLocalMove(new Vector3(x, -641, 0), 0.4f);
            sq.Append(tw);
            sq.AppendCallback(() => {
                //移动动画之后在进行消除,
                Deck.Instance.check();
                Deck.Instance.optCard = true;//允许操作
            });
            sq.Play();//动作队列运行
        }
    }
}
