using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    void Start() {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) { 
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);           //добавляем новую корзину в список
        }
    }

    public void AppleDestroyed() {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");  //этот метод возвращает массив всех существующих игровых объектов Apple
        foreach (GameObject tGO in tAppleArray) {                               //и уничтожаем их
            Destroy(tGO); 
        }
        //удаляем одну корзину
        int basketIndex = basketList.Count-1;               //получаем индекс последней корзины в basketList
        GameObject tBasketGO = basketList[basketIndex];     //получаем ссылку на этот игровой объект Basket
        basketList.RemoveAt(basketIndex);                   //удаляем корзину из списка 
        Destroy(tBasketGO);                                 //и удаляем сам игровой объект

        if(basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0");
        }
    }
    void Update() {
        
    }
}
