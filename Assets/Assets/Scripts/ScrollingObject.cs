using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    float Speed = 7.0f;
    
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
