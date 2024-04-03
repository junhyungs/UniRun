using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] CoinArray;

    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;

        for(int i = 0; i  < obstacles.Length; i++)
        {
            if(Random.Range(0,5) == 0)
                obstacles[i].SetActive(true);
            else
                obstacles[i].SetActive(false);
        }
        for (int i = 0; i  < CoinArray.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
                CoinArray[i].SetActive(true);
            else
                CoinArray[i].SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && !stepped)
        {
            if (collision.contacts[0].normal.y < 0)
            {
                stepped = true;
                GameManager.Instance.AddScore(1);
            }
        }
    }
}
