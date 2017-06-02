using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    private GameObject Object = null;
    [SerializeField]
    float Radius = 0.0f;
    [SerializeField]
    float Speed = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _Radius = Vector3.Distance(Object.transform.position, transform.position);

        if(_Radius <= Radius)
        {
            //transform.position = Vector3.Lerp(Object.transform.position, transform.position, Speed);
            float angle = Mathf.Atan2(Object.transform.position.z - transform.position.z, Object.transform.position.x - transform.position.x);
            transform.position += new Vector3(Mathf.Cos(angle) * Speed, 0.0f, Mathf.Sin(angle) * Speed);
        }
    }
}
