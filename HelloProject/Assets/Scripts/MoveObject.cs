using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public int Hp = 10;                  //ü�� ����
    public float Distance = 0;           //�̵� �Ÿ�

    public int NeedHp = 2;                  //�ʿ� ü�� 
    public float MoveDistance = 3.5f;       //�̵� ���� �Ÿ�

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))         //Ű �Է��� ���� Update���� ���� �ϰ� if���� ���ؼ� Ű�� �Է��� �Ǿ��� ��[�����̽��� ������ ��]
        {
            if (NeedHp > Hp)
            {
                Debug.Log("�� �̻� �̵� �� �� �����ϴ�. ");    //ü���� �����Ƿ� �̵� �� �� ����. 
            }
            else
            {
                ObjectMove(NeedHp, MoveDistance);     //�Լ��� ���� �̵� ��Ų��. 
            }
        }
    }

    void ObjectMove(int _Hp, float _MoveDistance)
    {
        Hp = Hp - _Hp;                              //�Լ� �����Ҷ� �μ��� �޾ƿ� Hp�� ����.
        Distance = Distance + _MoveDistance; ;      //�Լ� �����Ҷ� �μ��� �޾ƿ� �Ÿ��� ���Ѵ�. 

        Debug.Log("���� ü�� : " + Hp);
        Debug.Log("�̵� �Ÿ� : " + Distance);
    }
}
