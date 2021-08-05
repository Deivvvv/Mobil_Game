using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthZone : MonoBehaviour
{
    [SerializeField]
    private GameObject head;
    private void OnTriggerStay(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.GetComponent<PathObject>())
        {
            if(go.GetComponent<PathObject>().StaicObject == false)
            {
                if(go.transform.position.z > head.transform.position.z)
                {
                    go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z-0.25f);
                }
                else
                {
                    go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + 0.25f);
                }
            }
        }
    }
}
