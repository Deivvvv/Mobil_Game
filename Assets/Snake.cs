using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private MapMenager mapMenager;
    private SnakeMove snakeMove;
    private SnakeTail snakeTail;

    private int colorSnake;
    private int score;


    private int scoreUber;
    private int uber;
    public bool uberMod;
    public float uberTime;
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (uberMod)
        {
            uberTime -= 0.1f;
            if (uberTime <= 0)
            {
                snakeMove.Uber(false);
                uberMod =false;
            }
        }
    }

    public void Eat(PathObject pathObject)
    {
        if (pathObject.Color == colorSnake)
        {
            uber = 0;
            score++;
            Destroy(pathObject.gameObject);
        }
        else if (pathObject.Color == -1)
        {
            scoreUber++;
            uber++;
            if (uber >= 3)
            {
                if (!uberMod)
                {
                    snakeMove.Uber(true);
                }

                uberTime = 3;
                uberMod = true;
            }
            Destroy(pathObject.gameObject);
        }
        else
        {
            if (uberMod)
            {
                Destroy(pathObject.gameObject);
            }
            else
            {
                ReSet();
            }
        }
    }

    private void ReSet()
    {
        score = 0;
    }

}
