using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    //ĳ������ �������� ������ �����. 
    public string characterName = "���";                          //���ڿ� ���� ���� (string)
    public char bloodType = 'A';                                   //���� ���� ���� (char)
    public int age = 17;                                           //���� ���� ���� (int)
    public float height = 168.3f;                                  //�Ǽ� ���� ����(float)
    public bool isFemale = true;                                   //�� ������ �Ǻ��ϴ� ���� ���� (bool)

    // Start is called before the first frame update
    void Start()
    {

        //������ ������ �ֿܼ� ��� 
        Debug.Log("ĳ���� �̸� : " + characterName);             //ĳ���� �̸� : ���
        Debug.Log("������ : " + bloodType);                      //������ : A
        Debug.Log("���� : " + age.ToString());                   //Debug.Log("���� : " + age) �� ���� ������ ������ �� ��ȯ�� ���ִ°��� ����.
        Debug.Log("Ű : " + height.ToString());                  //Debug.Log("Ű :" +  height) �� ���� ������ ������ �� ��ȯ�� ���ִ°��� ����.
        Debug.Log("�����ΰ�? : " + isFemale.ToString());            //Debug.Log("�����ΰ�? : " + isFemale)�� ���� ������ ������ �� ��ȯ�� ���ִ°��� ����.
    }

}
