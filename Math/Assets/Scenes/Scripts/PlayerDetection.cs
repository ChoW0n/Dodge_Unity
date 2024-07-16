using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float viewRadius = 5.0f;     //�þ� �Ÿ� 5
    public float viewAngle = 90f;       //�þ� ���� 90��
    public LayerMask enemyLayer;        //�� ���̾�

    public List<Transform> detectedEnemies = new List<Transform>();     //�þ� �ȿ� ���� �� ����Ʈ


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()        //���� Ž���ϴ� �Լ�
    {
        detectedEnemies.Clear();

        Collider[] enemiesInRadius = Physics.OverlapSphere(transform.position, viewRadius, enemyLayer);     //�þ� �Ÿ� ���� �ִ� ��� �ö��̴��� �����´�.

        foreach (Collider enemyCollider in enemiesInRadius)                                         //enemiesInRadius �迭�� ��ȯ�Ѵ�
        {
            Transform enemy = enemyCollider.transform;                                              //��ġ ���� ���� Transfrom ���� �����´�
            Vector3 directionToEnemy = (enemy.position - transform.position).normalized;            //���� ���� ���� Vector ��

            float dotProduct = Vector3.Dot(transform.forward, directionToEnemy);                    //���� ���
            float viewThreshold = Mathf.Cos(viewAngle * 0.5f * Mathf.Deg2Rad);                      //cos(viewAngle/2) �� ��

            if (dotProduct > viewThreshold)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);       //���� ������ �Ÿ��� ���Ѵ�.
                //���̾� ����ũ : ~enemyLayer�� ����Ͽ� �� ���̾ ������ ��� ���̾� üũ
                if (!Physics.Raycast(transform.position, directionToEnemy, ~enemyLayer))
                {
                    detectedEnemies.Add(enemy);
                    Debug.Log("�� Ž�� : " + enemy.name);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;                                  //�þ� ������ �Ķ��� ��
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Gizmos.color = Color.yellow;                                //�þ� ���� (�����)
        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);

        //��ä�� ��� �׸�
        Vector3 prevPoint = transform.position + viewAngleA * viewRadius;
        for (float angle = -viewAngle / 2; angle <= viewAngle / 2; angle += 5)
        {
            Vector3 newPont = transform.position + DirFromAngle(angle, false) * viewRadius;
            Gizmos.DrawLine(prevPoint, newPont);
            prevPoint = newPont;
        }
    }

    Vector3 DirFromAngle(float angleDegrees, bool anglelsGlobal)
    {
        if (!anglelsGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }
}
