using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            //i�� 0���� �����Ͽ� 9�� �� ������ i�� 1�� ������Ű��, �� 10ȸ �ݺ� ���� 
            Debug.Log(i + " ��° ���� �Դϴ�. ");
        }
    }
}