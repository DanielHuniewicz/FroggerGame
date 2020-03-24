using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool moveRight;

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
