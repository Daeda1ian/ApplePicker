using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    static public int score = 1000;
    void Awake() {  //Awake вызывается при создании экземпляра текущего класса, то есть всегда перед Start
        if(PlayerPrefs.HasKey("HighScore")) {   //PlayerPrafs - это словарь значения, на которые можно ссылаться по ключам. Проверяем наличие значения "HighScore"
            score = PlayerPrefs.GetInt("HighScore");   //если это значение имеется - читаем его
        }
        PlayerPrefs.SetInt("HighScore", score);  //сохраняем текущее значение score в хранилище PlayerPrefs с ключом "HighScore"
    }
    void Update() {
        Text gt = this.GetComponent<Text>();    //получаем компонент Text из текущего объекта
        gt.text = "High Score: " + score;       //меняем текст, использую целочисленную переменную для подсчета очков
        if(score > PlayerPrefs.GetInt("HighScore")) {   //проверяем текущее значение score в каждом кадре
            PlayerPrefs.SetInt("HighScore", score);     //и если оно превысит значение, хранящееся в PlayerPrefs, запишет его в хранилище
        }
    }
}
