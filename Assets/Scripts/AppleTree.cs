using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;            //шаблон дл€ создани€ €блок
    public float speed = 1f;                  //скорость движени€ €блок
    public float leftAndRightEdge = 10f;      //–ассто€ние, на котором должно измен€тьс€ направление движени€ €блони
    public float chanceToChangeDirections = 0.1f;  //¬еро€тность случайного изменени€ направлени€ движени€
    public float secondBetweenAppleDrops = 1f;     //„астота создани€ экземпл€ров €блок
    void Start() {
        //сбрасывать €блоки раз в секунду
        Invoke("DropApple", 2f);            //Invoke() вызывает функцию, заданную именем, через указанное число секунд. 
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);  // создает экземпл€р applePrefab и присваивает его переменнойapple типа GameObject.
        apple.transform.position = transform.position;       //устанавливаем местоположение этого нового объекта равным местоположению €блони
        Invoke("DropApple", secondBetweenAppleDrops);
    }
    void Update() {
        //простое перемещение
        Vector3 pos = transform.position;     //определ€ем локальную переменную дл€ хранени€ текущей позиции €блони
        pos.x += speed * Time.deltaTime;      // омпонент х переменной pos увеличиваетс€ на произведение скорости speed и интервала времени Time.deltaTime
        transform.position = pos;       //измененное значение pos присваиваетс€ обратно свойству transform. Ѕез этого перемещени€ €блони не произойдет

        if (pos.x < -leftAndRightEdge) {   //ѕроверить, не оказалось ли значение pos.х, только что установленное в предыдущих строках, меньше отрицательного значени€ предела leftAndRightEdge.
            speed = Mathf.Abs(speed);          //начать движение вправо
        }
        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);         //начать движение влево
        }
    }

    void FixedUpdate() {
        if (Random.value < chanceToChangeDirections) 
            speed *= -1;           //смена направлени€ движени€ €блони
    }
}
