using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool moveRight;
    public bool isTurtle;

    void Start()
    {
        // Jesli obiekt jest zółwiem to wykonuje sie animacja znikającego obiektu
        // animacja posiada randomizer
        if (isTurtle)
        {
            Animator anim = GetComponent<Animator>();
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            anim.Play(state.fullPathHash, -1, Random.Range(3f, 6f));
        }
    }

    // Funcja nadaje odpowiedni ruch obiektowi oraz przenosi go na ustawione miejsce
    // jezeli obiekt dojdzie do konkretnego punktu (dajac efekt zapętlenia)
    void Update()
    { 
        Vector2 pos = transform.localPosition;

        if (moveRight)
        {
            pos.x += Vector2.right.x * moveSpeed * Time.deltaTime;

            if (pos.x >= 25)
            {
                pos.x = -25;
            }
        }
        else
        {
            pos.x += Vector2.left.x * moveSpeed * Time.deltaTime;

            if (pos.x <= -30)
            {
                pos.x = 30;
            }
        }
        transform.localPosition = pos;
    }
}
