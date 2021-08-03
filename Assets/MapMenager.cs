using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenager : MonoBehaviour
{
    private GameObject oldPath;
    [SerializeField]
    private GameObject fragmentPath;

    private int curentPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPath()
    {
        Destroy(oldPath);

        Instantiate(fragmentPath, new Vector3(curentPath * 50, 0, 0), transform.rotation);
    }
}
