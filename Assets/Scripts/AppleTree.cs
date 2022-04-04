using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;            //������ ��� �������� �����
    public float speed = 1f;                  //�������� �������� �����
    public float leftAndRightEdge = 10f;      //����������, �� ������� ������ ���������� ����������� �������� ������
    public float chanceToChangeDirections = 0.1f;  //����������� ���������� ��������� ����������� ��������
    public float secondBetweenAppleDrops = 1f;     //������� �������� ����������� �����
    void Start() {
        //���������� ������ ��� � �������
        Invoke("DropApple", 2f);            //Invoke() �������� �������, �������� ������, ����� ��������� ����� ������. 
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);  // ������� ��������� applePrefab � ����������� ��� ����������apple ���� GameObject.
        apple.transform.position = transform.position;       //������������� �������������� ����� ������ ������� ������ �������������� ������
        Invoke("DropApple", secondBetweenAppleDrops);
    }
    void Update() {
        //������� �����������
        Vector3 pos = transform.position;     //���������� ��������� ���������� ��� �������� ������� ������� ������
        pos.x += speed * Time.deltaTime;      //��������� � ���������� pos ������������� �� ������������ �������� speed � ��������� ������� Time.deltaTime
        transform.position = pos;       //���������� �������� pos ������������� ������� �������� transform. ��� ����� ����������� ������ �� ����������

        if (pos.x < -leftAndRightEdge) {   //���������, �� ��������� �� �������� pos.�, ������ ��� ������������� � ���������� �������, ������ �������������� �������� ������� leftAndRightEdge.
            speed = Mathf.Abs(speed);          //������ �������� ������
        }
        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);         //������ �������� �����
        }
    }

    void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) 
            speed *= -1;           //����� ����������� �������� ������
    }
}
