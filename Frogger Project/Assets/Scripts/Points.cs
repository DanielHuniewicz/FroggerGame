using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Wejscie obiektu z obiektem otagowanym jako Player 
    // zwiekszy liczbe punktow o 10
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Score.pointAmount += 10;
            gameObject.SetActive(false);
        }
    }
}
