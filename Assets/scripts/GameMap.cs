using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    //��ƬԤ������Դ����
    public GameObject cardPrefab = null;

    int[] data = new int[27];

    void Start()//��ʼ��
    {
        //�����������(��������)
        transform.localPosition = Vector3.zero;
        this.initData();//��ʼ������

        this.createCards();//������Ƭ
    }

    void initData()
    {
        //��˳���ʼ��
        for (int i = 0, n = 0; i < 3; i++)//3��id
        {
            for (int j = 0; j < 9; j++)//�ظ��Ŵ�
            {
                this.data[n++] = i;
            }
        }
        int leng = this.data.Length;
        //�������������� ϴ�ƺ���
        for(int i=0;i<leng;i++)
        {
            int index = Random.Range(0, leng - i);
            //����������
            //leng-1
            int temp = data[index];
            data[index] = data[leng - 1 - i];
            data[leng - 1 - i] = temp;
        }
        
    }
    void createCards()//������Ƭ
    {
        for (int i = 0, n = 0; i < 3; i++)//3��  3  3
        {
            for (int j = 0; j < 3; j++)//�� -- y
            {
                for (int k = 0; k < 3; k++)//��  --x
                {
                    //�ڶ���: ��Ҫ��Ԥ���崴��һ���µĽڵ�(����)
                    GameObject cardGo = Instantiate(cardPrefab);
                    //������:��Ҫ�����㼶��ϵ,���´���������,���õ���ͼ��
                    //��Ƭ�ڵ����ø��׽ڵ�Ϊ��ǰ��ͼ�ڵ�
                    cardGo.transform.SetParent(this.transform);
                    //���Ĳ�:�����ڵ������ λ��
                    //�����ڵ�ͼ��ԭ��λ��
                    float x = -200 + k * 200;
                    float y = j * 200 + i * 10;
                    cardGo.transform.localPosition = new Vector3(x,y,0);
                    //��ȡ��Ƭ���
                    Card _card = cardGo.GetComponent<Card>();
                    _card.setID(this.data[n++]);
                }
            }
        }
    }
}