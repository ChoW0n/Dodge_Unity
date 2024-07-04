using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            //i는 0부터 시작하여 9가 될 때까지 i를 1씩 증가시키며, 총 10회 반복 실행 
            Debug.Log(i + " 번째 순번 입니다. ");
        }
    }
}