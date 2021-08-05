using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenager : MonoBehaviour
{
    [SerializeField]
    private GameObject snake;
    [SerializeField]
    private Material[] color;
    private int curentColor;
    private int secondColor;

    private GameObject oldPath;
    private GameObject curentPath;
    [SerializeField]
    private GameObject fragmentPath;

    private int curentPathNum;

    [SerializeField]
    private GameObject[] objectList;
    public void ReSet()
    {
        Destroy(oldPath);
        Destroy(curentPath);
        curentPathNum = 0;
        NewPath();

       // snake.transform.position.x
    }

    // Start is called before the first frame update
    void Start()
    {
        NewPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddObject(Vector3 v, int id)
    {
        int createObject = 0;
        if(id == -1)
        {
            createObject = 1;
        }
        else if (id >=0)
        {
            createObject = 2;
        }
        GameObject GO = Instantiate(objectList[createObject]);
        GO.transform.position = v;
        GO.transform.SetParent(curentPath.transform);

        GO.GetComponent<PathObject>().Color = id;
        if (id < 0)
            GO.GetComponent<PathObject>().StaicObject = true;


    }
    private void SpawnObject()
    {
        //-10 =50 x
        // 3-0--3 z
        for(int i=0; i < 6; i++)
        {

            //GameObject GO = Instantiate(originalTail);
            //tail[i] = GO.GetComponent<Rigidbody>();
            //GO.transform.position = new Vector3(head.transform.position.x - 0.5f - 0.125f * i, head.transform.position.y, head.transform.position.z);
            ////GO.transform.SetParent(gridLayout.transform);
            ////GO.name = "Grid" + i;
        }
    }

    private void NewColor()
    {
        curentColor = Random.Range(0, color.Length + 1);
        secondColor = curentColor;
        while (secondColor != curentColor)
        {
            secondColor = Random.Range(0, color.Length + 1);
        }

    }
    public void NewPath()
    {
        Destroy(oldPath);
        oldPath = curentPath;

        curentPath = Instantiate(fragmentPath, new Vector3(curentPathNum * 100, 0, 0), transform.rotation);
        curentPathNum++;
        NewColor();
    }
}
