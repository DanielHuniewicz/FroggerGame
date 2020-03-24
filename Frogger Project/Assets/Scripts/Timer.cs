using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerBar;
    public float maxTime;
    public float timeLeft;
    public FrogPlayer player;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Funkcja zmniejszajaca czas oraz Sprite obiektu timerBar w sposób
    // napełnania sprite
    // Jezlei czas dojdzie do konca to wykona sie funkcja TimeUp()
    void Update()
    {
        if(timeLeft > 0) 
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else 
        {
            Debug.Log("Time Up");
            player.TimeUp();
        }
    }
}
