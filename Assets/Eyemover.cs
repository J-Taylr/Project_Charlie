using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyemover : MonoBehaviour
{
    bool reached = true;
    Vector2 randomPos;
    public float speed;
    public float buffer;
    public float minRange;
    public float maxRange;

    private void Update()
    {
        MoveEye();
    }


    void MoveEye()
    {
        if (reached || randomPos == null)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            randomPos = transform.position;
            randomPos.x += Random.Range(minRange, maxRange);
            randomPos.y += Random.Range(minRange, maxRange);
            reached = false;
            print(randomPos);
        }

        transform.position = (Vector3)Vector2.Lerp(transform.position, randomPos, Time.deltaTime * speed);

        float distanceBetween = Vector2.Distance(transform.position, randomPos);

        if (distanceBetween <= buffer)
        {
            reached = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        reached = true;
        print("collided with" + gameObject.name);
    }
}
