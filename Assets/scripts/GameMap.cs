using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public static GameMap instance=null;

   
    //��ƬԤ������Դ����
    public GameObject cardPrefab = null;

    public int level = 1;//Ĭ��ֵ �ڽ���������
    public int totalNum = 27;//Ĭ��ֵ �ڽ���������
    int[] data = null;//����
    Card[] cards = null;//�ؿ����п�Ƭ

    void Start()//��ʼ��
    {
        GameMap.instance = this;
        //�����������(��������)
        transform.localPosition = Vector3.zero;
        data = new int[totalNum];//����
        cards = new Card[totalNum];//�ؿ����п�Ƭ
        switch(level)
            {
            case 1:
                {

                this.initData_1();//��ʼ������
                this.createCards_1();//������Ƭ
            }
                break;
            case 2:
                {
                    this.initData_2();//��ʼ������
                    this.createCards_2();//������Ƭ

                }
                break;
        }

       
    }

    void initData_1()
    {
        //��˳���ʼ��
        for (int i = 0, n = 0; i < 3; i++)//3��ID
        {
            for (int j = 0; j < 9; j++)//�ظ�9��
            {
                this.data[n++] = i;
            }
        }
        //��������������  ϴ���㷨
        int leng = this.data.Length;
        for (int i = 0; i < leng; i++)
        {
            int index = Random.Range(0, leng - i);
            //����������
            //leng - 1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
    }
    void createCards_1()//������Ƭ
    {
        int n = 0;
        for (int i = 0; i < 3; i++)//3�� 
        {
            for (int j = 0; j < 3; j++)//3�� -- y
            {
                for (int k = 0; k < 3; k++)//3��  --x
                {
                    //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
                    //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
                    cardGo.transform.SetParent(this.transform);
                    //���Ĳ�:�����ڵ������ λ��
                    //�����ڵ�ͼ��ԭ��λ��
                    float x = -200 + k * 200+i*10;
                    float y = j * 200 + i * 25;
                    cardGo.transform.localPosition = new Vector3(x, y, 0);
                    //��ȡ��Ƭ���
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n], n);
                    cards[n] = _card;
                    n++;
                }
            }
        }
            //�ڵ���ϵ
        for (int i = 0; i < totalNum; i++)
        {
            for (int j = 0; j < totalNum; j++)
            {
                cards[i].onCollid(cards[j]);//��ײ���
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
        //��������������  ϴ���㷨
        int leng = this.data.Length;
        for (int i = 0; i < leng; i++)
        {
            int index = Random.Range(0, leng - i);
            //����������
            //leng - 1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
    }
    void createCards_2()
    {
        int n = 0;//������ʼ
        //���һ��40
        for (int i = 0; i < 40; i++)//
        {
            //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
            GameObject cardGo = Instantiate(cardPrefab);
            //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
            //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
            cardGo.transform.SetParent(this.transform);
            //���Ĳ�:�����ڵ������ λ��
            //�����ڵ�ͼ��ԭ��λ��
            float x = -466;
            float y = 625-i*10;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //��ȡ��Ƭ���
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //�ұ�һ��40
        for (int i = 0; i < 40; i++)//
        {
            //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
            GameObject cardGo = Instantiate(cardPrefab);
            //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
            //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
            cardGo.transform.SetParent(this.transform);
            //���Ĳ�:�����ڵ������ λ��
            //�����ڵ�ͼ��ԭ��λ��
            float x = 466;
            float y = 40 + i * 10;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //��ȡ��Ƭ���
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //���һ��37
        for(int i=0;i<37;i++)
        {
            //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
            GameObject cardGo = Instantiate(cardPrefab);
            //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
            //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
            cardGo.transform.SetParent(this.transform);
            //���Ĳ�:�����ڵ������ λ��
            //�����ڵ�ͼ��ԭ��λ��
            float x = -110-i*10;//-����ƫ��
            float y = -265;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //��ȡ��Ƭ���
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //�ұ�һ��37
        for (int i = 0; i < 37; i++)
        {
            //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
            GameObject cardGo = Instantiate(cardPrefab);
            //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
            //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
            cardGo.transform.SetParent(this.transform);
            //���Ĳ�:�����ڵ������ λ��
            //�����ڵ�ͼ��ԭ��λ��
            float x = 110 +i * 10;//-����ƫ��
            float y = -265;
            cardGo.transform.localPosition = new Vector3(x, y, 0);
            //��ȡ��Ƭ���
            Card _card = cardGo.GetComponent<Card>();
            _card.setID(this.data[n], n);
            cards[n] = _card;
            n++;
        }

        //���Ĳ��� 7��7�� 8��
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)// -- y
            {
                for (int k = 0; k < 7; k++)//  --x
                {
                    //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
                    //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
                    cardGo.transform.SetParent(this.transform);
                    //���Ĳ�:�����ڵ������ λ��
                    //�����ڵ�ͼ��ԭ��λ��
                    float x = -270 + k * 90;
                    float y = -100+j*100;
                    if (j % 2 == 0)
                    {
                        x -= 20;
                        x -= i * 10;
                    }
                    else
                    {
                        x += 20;
                        x += i * 10;
                    }
                    cardGo.transform.localPosition = new Vector3(x, y, 0);
                    //��ȡ��Ƭ���
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n], n);
                    cards[n] = _card;
                    n++;
                }
            }
        }

        //�ڵ���ϵ����
        for (int i = 0; i < totalNum; i++)
        {
            for (int j = 0; j < totalNum; j++)
            {
                cards[i].onCollid(cards[j]);//��ײ���
            }
        }
    }
}
