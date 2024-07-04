using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    //캐릭터의 프로필을 변수로 만든다. 
    public string characterName = "라라";                          //문자열 변수 선언 (string)
    public char bloodType = 'A';                                   //문자 변수 선언 (char)
    public int age = 17;                                           //정수 변수 선언 (int)
    public float height = 168.3f;                                  //실수 변수 선언(float)
    public bool isFemale = true;                                   //참 거짓을 판별하는 변수 선언 (bool)

    // Start is called before the first frame update
    void Start()
    {

        //생성한 변수를 콘솔에 출력 
        Debug.Log("캐릭터 이름 : " + characterName);             //캐릭터 이름 : 라라
        Debug.Log("혈액형 : " + bloodType);                      //혈액형 : A
        Debug.Log("나이 : " + age.ToString());                   //Debug.Log("나이 : " + age) 와 같은 동작을 하지만 형 변환를 해주는것이 좋다.
        Debug.Log("키 : " + height.ToString());                  //Debug.Log("키 :" +  height) 와 같은 동작을 하지만 형 변환를 해주는것이 좋다.
        Debug.Log("여성인가? : " + isFemale.ToString());            //Debug.Log("여성인가? : " + isFemale)와 같은 동작을 하지만 형 변환를 해주는것이 좋다.
    }

}
