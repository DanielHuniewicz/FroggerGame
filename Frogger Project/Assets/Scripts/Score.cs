using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public Text textFinal;
    public Text scoreFinal;
    public Timer timer;

    float punkty;
    public static int pointAmount;
    public static int totallPointAmount;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public GameObject point7;
    public GameObject point8;
    public GameObject point9;
    public GameObject point10;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Zaladowanie zdobytych punktow przez gracza do Textu w UI
    // oraz ich przetworzenie (pomnzoenie zdobytych punktow przez czas) 
    // do Textu finalnego w panelu Win 
    void Update()
    {
        text.text = (pointAmount + totallPointAmount).ToString();
        punkty = (totallPointAmount * 10 + timer.timeLeft * 20);
        scoreFinal.text = punkty.ToString("0.00");
    }

    // Aktywowanie na nowo obiektow typu point
    public void SpawnPoints()
    {
        //pointsPos = gameObject.transform.position;
        // gameObject.SetActive(true);
        // GameObject.FindGameObjectsWithTag("myTag").SetActive(false);
        /*
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Point");
        foreach (GameObject gameObj in gameObjects)
        {
            gameObj.SetActive(true);
        }
        */
        point1.SetActive(true);
        point2.SetActive(true);
        point3.SetActive(true);
        point4.SetActive(true);
        point5.SetActive(true);
        point6.SetActive(true);
        point7.SetActive(true);
        point8.SetActive(true);
        point9.SetActive(true);
        point10.SetActive(true);
    }
}
