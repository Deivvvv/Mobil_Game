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

    [SerializeField]
    private float snakeSpeed;
    [SerializeField]
    private float snakeUberSpeed;
    private Rigidbody rb;
    private float timeMatch;

    private SnakeTail snakeTail;

    private float time =1;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = snake.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;

        snakeTail = gameObject.GetComponent<SnakeTail>();// snakeTail.StartSys();
        snakeTail.StartSys(snake.transform.position, Speed);
        snakeTail.NewColor(snake.GetComponent<MeshRenderer>().material);
    }

    // Update is called once per frame
    public float Speed = 2;
    public Queue<Vector3> Points = new Queue<Vector3>();
    private Camera camera;
    private Vector3 velocity;

    //private void Start()
    //{
    //    camera = Camera.main;
    //}

    public void Uber(bool uber)
    {
        if (uber)
        {

        }
        else
        {

        }
    }

    void FixedUpdate()
    {
        time -= 0.3f;
        //if(Input.GetAxis("Mouse X") != 0)
        //        {
            var mouse = Input.mousePosition;
            Vector3 p;
          //  Debug.Log(look.transform.position);
            //if (camera.orthographic)
            //{
            //    p = camera.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0));
            //    p.z = 0;
            //}
            //else
            //{
            p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));


            float zPosition = p.z;

            if (p.z - 0.1f > look.transform.position.z)
            {
                if (p.z < 3f)
                {
                    zPosition = p.z;// - tailSpeed + tailSizeSpeed * i;
                }
                else
                {
                    zPosition = 3;
                }
            }
            else if (p.z + 0.1f < look.transform.position.z)
            {
                if (p.z > -3f)
                {
                    zPosition = p.z;// - tailSpeed + tailSizeSpeed * i;
                }
                else
                {
                    zPosition = -3;
                }
            }

            look.transform.position = new Vector3(snake.transform.position.x +snakeSpeed , 1.4f, zPosition);

            p = look.transform.position;

        if (time <= 0)
        {
            time = 1;
            Points.Enqueue(p);
        }


        while (Points.Count > 0 && Points.Peek().x < look.transform.position.x-1f)
        {
           snakeTail.SetPositionTail(Points.Peek());
            Points.Dequeue();
        }

        if (Points.Count > 0)
        {
            velocity = (Points.Peek() - snake.transform.position).normalized * Speed;
            snake.transform.position = Vector3.MoveTowards(transform.position, Points.Peek(), Speed * Time.deltaTime);
        }
        else
        {
            snake.transform.position += velocity * Time.deltaTime;
        }
    }

}
