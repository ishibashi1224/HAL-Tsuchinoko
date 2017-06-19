using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;    //ターゲットへの参照

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z +0.8f);

        if(target.position.z >= -10.0f && transform.position.y <= 30.0f )
        {
            transform.position += new Vector3(0, 1.0f, 0);
        }
    }
}
