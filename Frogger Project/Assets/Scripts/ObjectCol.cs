using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCol : MonoBehaviour
{

    Rect playerRect;
    Vector2 playerSize;
    Vector2 playerPosition;

    Rect colObjectRect;
    Vector2 colObjectSize;
    Vector2 colObjectPosition;

    public bool isSafe;
    public bool isLog;

    // Funkcja sprawdzajaca czy punkt kolizyjny obiektu gracza wchodzi w kolizje z innym
    // obiektem kolizyjnym, oba obiekty posiadaja pole stworzone za pomoca polecenia Rect
    // a ich wymiary to wymiary dodanych Spritów
    public bool IsColliding (GameObject playerGameObject) 
    {
        playerSize = playerGameObject.transform.GetComponent<SpriteRenderer>().size;
        playerPosition = playerGameObject.transform.localPosition;

        colObjectSize = GetComponent<SpriteRenderer>().size;
        colObjectPosition = transform.localPosition;
  
        playerRect = new Rect(playerPosition.x - playerSize.x /2, playerPosition.y - playerSize.y /2, playerSize.x, playerSize.y);
        colObjectRect = new Rect(colObjectPosition.x - colObjectSize.x /2, colObjectPosition.y - colObjectSize.y /2, colObjectSize.x, colObjectSize.y);

        if (colObjectRect.Overlaps(playerRect, true))
        {
            return true;
        }
        return false;
    }
}
