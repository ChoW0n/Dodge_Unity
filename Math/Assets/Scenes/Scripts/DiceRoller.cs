using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public GameObject dicePrefabs;          //���̽� ������Ʈ
    public float throwForce = 5.0f;         //���̽� ������ ��
    public float torqueForce = 2f;          //���̽� ȸ����

    private Rigidbody diceRigidbody;        //���̽� ��ü
    private bool isRolling = false;         //�Ѹ� �÷���
    private Vector3[] diceDirections = new Vector3[6];  //6��ü Vector�� ����
    // Start is called before the first frame update
    void Start()
    {
        //�ֻ��� ���� �ʱ�ȭ
        diceDirections[0] = Vector3.forward;        //1
        diceDirections[1] = Vector3.up;             //2
        diceDirections[2] = Vector3.left;           //3
        diceDirections[3] = Vector3.right;          //4
        diceDirections[4] = Vector3.down;           //5
        diceDirections[5] = Vector3.back;           //6
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //�����̽��� ������ ���̽��� �Ѹ� ������ ���� ��
        {
            RollDice();
        }

        if (isRolling && diceRigidbody.IsSleeping())    //�Ѹ� ���� �����̰� ��ü�� ������ ��
        {
            CheckDiceResult();
            isRolling = false;
        }
    }

    void RollDice()
    {
        GameObject diceInsance = Instantiate(dicePrefabs, transform.position, Random.rotation);     //���̽� �������� �����Ѵ�. ȸ���� �����̴�.
        diceRigidbody = diceInsance.GetComponent<Rigidbody>();                                      //������ ���̽� �����տ��� ��ü�� �����´�
        
        //�ֻ����� �������� ���� ����
        diceRigidbody.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
        
        //�ֻ����� ȸ������ ����
        diceRigidbody.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);

        isRolling = true;                                                                           //ȸ�� ���¸� true�� �����Ѵ�.

    }

    void CheckDiceResult()          //���̽� ��� üũ �ϴ� �Լ�
    {
        float bestDotProduct = float.NegativeInfinity;
        int result = 0;

        for (int i = 0; i < 6; i++)
        {
            //�ֻ��� ���� ��ǥ���� ������ ���� ��ǥ��� ��ȯ
            Vector3 worldDirection = diceRigidbody.transform.TransformDirection(diceDirections[i]);
            //���� ��ǥ�� ��ȯ�� ����� ������ ���
            float dotProduct = Vector3.Dot(worldDirection, Vector3.up);

            if (dotProduct < bestDotProduct)
            {
                bestDotProduct = dotProduct;
                result = i + 1;     //�ε����� 0���� �����ϹǷ� 1�� ���ؼ� ������� �˷��ش�.
            }
        }

        

        //������ ����Ͽ� �ֻ����� ȸ�� ���� Ȯ��
        Vector3 diceRight = diceRigidbody.transform.right;
        Vector3 diceForward = diceRigidbody.transform.forward;
        Vector3 rotationDirection = Vector3.Cross(diceRight, diceForward);

        if (Vector3.Dot(rotationDirection, Vector3.up) > 0)
        {
            Debug.Log("�ֻ����� �ð� �������� ȸ��");
        }
        else
        {
            Debug.Log("�ֻ����� �ݽð� �������� ȸ��");
        }

        Debug.Log("�ֻ��� ��� : " + result);
    }
}
