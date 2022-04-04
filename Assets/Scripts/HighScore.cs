using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    static public int score = 1000;
    void Awake() {  //Awake ���������� ��� �������� ���������� �������� ������, �� ���� ������ ����� Start
        if(PlayerPrefs.HasKey("HighScore")) {   //PlayerPrafs - ��� ������� ��������, �� ������� ����� ��������� �� ������. ��������� ������� �������� "HighScore"
            score = PlayerPrefs.GetInt("HighScore");   //���� ��� �������� ������� - ������ ���
        }
        PlayerPrefs.SetInt("HighScore", score);  //��������� ������� �������� score � ��������� PlayerPrefs � ������ "HighScore"
    }
    void Update() {
        Text gt = this.GetComponent<Text>();    //�������� ��������� Text �� �������� �������
        gt.text = "High Score: " + score;       //������ �����, ��������� ������������� ���������� ��� �������� �����
        if(score > PlayerPrefs.GetInt("HighScore")) {   //��������� ������� �������� score � ������ �����
            PlayerPrefs.SetInt("HighScore", score);     //� ���� ��� �������� ��������, ���������� � PlayerPrefs, ������� ��� � ���������
        }
    }
}
