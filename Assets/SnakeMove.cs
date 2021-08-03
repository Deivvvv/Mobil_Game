using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField]
    private GameObject look;

    [SerializeField]
    private bool stop;

    [SerializeField]
    private GameObject snake;


    [SerializeField]
    private GameObject touch;

    private Rigidbody rb;
    private float timeMatch;
    // Start is called before the first frame update
    void Start()
    {
        rb = snake.GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stop)
        {//rb.velocity
            int zPosition = 0;
            look.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if (look.transform.position.x - 0.1f < snake.transform.position.x)
            {
                if (snake.transform.position.z < 2)
                    zPosition = 5;
            }
            else if (look.transform.position.x + 0.1f > snake.transform.position.x)
            {

                if (snake.transform.position.z > -2)
                    zPosition = -5;
            }



                    //if (look.transform.position.x < snake.transform.position.x) 
                    //{
                    //    if (snake.transform.position.z < 5)
                    //    {
                    //        snake.transform.position += new Vector3(0,0, 5f * Time.deltaTime);
                    //    }

                    //}
                    //else //if (look.transform.position.x < snake.transform.position.x)
                    //{
                    //    if (snake.transform.position.z > -5)
                    //    {
                    //        snake.transform.position -= new Vector3(0, 0, 5f * Time.deltaTime);
                    //    }

                    //}
                    //snake.transform.position += new Vector3(5f * Time.deltaTime, 0, 0);

                    rb.velocity = new Vector3(5f,0, zPosition);
            //   Transform v = GameObject.transform;//.position
            //  snake.transform.position -= new Vector3(snake.transform.position.x + 0.1f, snake.transform.position.y, snake.transform.position.z);
        }
    }
}
