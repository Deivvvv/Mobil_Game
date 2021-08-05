using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    [SerializeField]
    private Snake snake;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.GetComponent<PathObject>())
        {
            snake.Eat(go.GetComponent<PathObject>());
        }
    }
}
