using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private GameObject originalTail;

    [SerializeField]
    private int tailSize =5;
    [SerializeField]
    private Rigidbody[] tail;

    [SerializeField]
    private float tailSpeed;


    private int curentColor;
    public List<Vector3> target = new List<Vector3>();

    public void NewStage()
    {

    }

    private void CreateTail()
    {
        tail = new Rigidbody[tailSize];
        for (int i = 0; i < tailSize; i++)
        {
            GameObject GO = Instantiate(originalTail);
            tail[i] = GO.GetComponent<Rigidbody>();
            GO.transform.position = new Vector3(head.transform.position.x-0.5f-0.125f*i, head.transform.position.y, head.transform.position.z);
            //GO.transform.SetParent(gridLayout.transform);
            //GO.name = "Grid" + i;

            //GO.GetComponent<TilemapRenderer>().sortingOrder = i;
            //mapData.level[i] = GO.GetComponent<Tilemap>();
        }
    }
    public void SetPositionTail(Vector3 v)
    {
     //   Vector3 position = new Vector3(0, 0, 0);
        for(int i = target.Count-1;i >0; i--)
        {

            target[i] = target[i - 1];
        }
        target[0] = v;
    }


    public void NewColor(Material material)
    {
        for (int i = 0; i < tailSize; i++)
        {
            if (i % 3 > 0)
                tail[i].gameObject.GetComponent<MeshRenderer>().material = material;
        }
    }
    private void TailPosition()
    {
        for (int i = 0; i < tailSize; i++)
        {
            tail[i].transform.position = Vector3.MoveTowards(tail[i].transform.position, target[i], tailSpeed * Time.deltaTime);// = target[i];
           
        }
    }
    // Start is called before the first frame update
   public void StartSys(Vector3 v, float speed)
    {
        tailSpeed = speed;
        for (int i =0; i < tailSize; i++)
        {
            target.Add(v);
        }
        head = gameObject;
        CreateTail();
        gameObject.GetComponent<SnakeTail>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TailPosition();
    }
}
