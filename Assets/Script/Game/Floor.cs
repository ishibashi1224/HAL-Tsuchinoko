using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private GameObject Object = null;
    private Material material = null;
    // Use this for initialization
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        if (GameObject.FindGameObjectsWithTag("EnemyBoss").Length > 0)
        {
            Object = GameObject.FindGameObjectWithTag("EnemyBoss");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Object == null)
        {
            if (GameObject.FindGameObjectsWithTag("EnemyBoss").Length > 0)
            {
                Object = GameObject.FindGameObjectWithTag("EnemyBoss");
            }
        }
        else
        {
            material.SetVector("_Vector", Object.transform.GetChild(0).transform.position);
        }
    }
}
