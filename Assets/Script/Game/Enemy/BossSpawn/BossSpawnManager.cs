using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<BossSpawn> Spawn = null;

    // Use this for initialization
    void Start()
    {
        Spawn[0].Create();
        //Spawn[0].Destruction();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("up"))
        //{
        //    Spawn[0].Create();
        //}
        //if (Input.GetKeyDown("down"))
        //{
        //    Spawn[0].Destruction();
        //}
    }
}
