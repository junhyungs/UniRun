using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject m_PlatformPrefab;
    public int m_Count = 3;

    public float m_TimeBetSpawnMin = 1.25f;
    public float m_TimeBetSpawnMax = 2.25f;

    public float m_YposMin = 3.5f;
    public float m_YposMax = 2.25f;

    private float m_Xpos = 13.0f;
    private Queue<GameObject> m_PlatformPool = new Queue<GameObject>();
    private Vector2 PoolPosition = new Vector2(0, -25);

    void Start()
    {
        for(int i = 0; i < m_Count; i++)
        {
            GameObject platform = Instantiate(m_PlatformPrefab, PoolPosition, Quaternion.identity);
            platform.SetActive(false);
            m_PlatformPool.Enqueue(platform);
        }
        StartCoroutine(SpawnPlatform());
    }
    private IEnumerator SpawnPlatform()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.9f);//Random.Range(m_TimeBetSpawnMin, m_TimeBetSpawnMax));

            float yPos = Random.Range(m_YposMin, m_YposMax);

            if (!GameManager.Instance.isGameOver)
            {
                GameObject platform = m_PlatformPool.Dequeue();
                m_PlatformPool.Enqueue(platform);
                platform.SetActive(false);
                platform.SetActive(true);
                platform.transform.position = new Vector2(m_Xpos, yPos);
            }
        }
    }
    
}
