using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Object;
    [SerializeField]
    private float interval = 0.0f;
    [SerializeField]
    private int NumMax = 0;
    private float time = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interval < time)
        {
            time = 0.0f;
            for (int count = 0; count < NumMax; count++)
            {
                Instantiate(Object[Random.Range(0, Object.Count - 1)], transform.position, transform.rotation);
            }

        }
        time += Time.deltaTime;
    }
}
