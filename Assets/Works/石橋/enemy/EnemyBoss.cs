using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject Object = null;
    [SerializeField]
    private RootMove rootmove = null;
    [SerializeField]
    private float statechangetime = 0;
    [SerializeField]
    private int probability = 0;

    private float time = 0;

    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > statechangetime)
        {
            time = 0;
            if (Random.Range(0, 100) < probability && rootmove.enabled == false)
            {
                rootmove.enabled = true;
            }
        }
    }
}
