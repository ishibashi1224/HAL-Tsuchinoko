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
    [SerializeField]
    private int Radius = 0;
    [SerializeField]
    private float StartTime = 0;


    private EnemySpawnManager Instance;
    private float time;
    private float startTimer;
    private float angle;

    // Use this for initialization
    void Start()
    {
        Instance = EnemySpawnManager.Instance;
        angle = (Mathf.PI * 2) / NumMax;
        time = 0.0f;
        startTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer >= StartTime)
        {
            if (interval < time)
            {
                time = 0.0f;
                for (int count = 0; count < NumMax; count++)
                {
                    Vector3 pos = transform.position + new Vector3(Mathf.Sin(angle * count) * Radius, 0, Mathf.Cos(angle * count) * Radius);
                    if (!Instance.Place(pos))
                    {
                        if (Instance.Creat())
                        {
                            Instance.Add(Instantiate(Object[Random.Range(0, Object.Count - 1)], pos, transform.rotation));
                        }
                    }
                }
            }
            time += Time.deltaTime;
        }
        else
        {
            startTimer += Time.deltaTime;
        }
    }
}
