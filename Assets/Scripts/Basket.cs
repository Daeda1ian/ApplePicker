using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;          //подключаем библиотеку дл€ работы с интерфейсом

public class Basket : MonoBehaviour {

    [Header("Set Dynamically")]
    public Text scoreGT;
    void Start() {
        GameObject scoreGO = GameObject.Find("ScoreCounter");   //метод Find отыскивает в сцене игровой объект в именем "ScoreCounter" и возвращает ссылку на него
        scoreGT = scoreGO.GetComponent<Text>();        //получить компонент Text этого игрового объекта
        scoreGT.text = "0";                            //установить начальное число очков равным 0
    }
    void Update() {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision) {    //вызываетс€ вс€кий раз, когда другой объект сталкиваетс€ с этой корзиной
        GameObject collidedWith = collision.gameObject;     //присваиваем локальной переменной ссылку на игровой объект, столкнувшийс€ с корзиной
        if (collidedWith.tag == "Apple") {                    //провер€ем, что этот объект именно €блоко по тегу
            Destroy(collidedWith);                          //и если это €блоко - уничтожаем

            int score = int.Parse(scoreGT.text);                //преобразовать текст в scoreGT в целое число
            score += 100;                                       //добавать очки за пойманое €блоко
            scoreGT.text = score.ToString();                    //преобразовать число очков обратно в строку и вывести ее на экран
            if(score > HighScore.score) {                     //запомнить высшее достижение
                HighScore.score = score;
            }
        }
    }
}
