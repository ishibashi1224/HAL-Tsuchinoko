using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    float Radius = 0.0f;
    [SerializeField]
    float Speed = 0.0f;
    private GameObject Target = null;

    // Use this for initialization

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _Radius = Vector3.Distance(Target.transform.position, transform.position);

        if(_Radius <= Radius)
        {
            //transform.position = Vector3.Lerp(Target.transform.position, transform.position, Speed);
            float angle = Mathf.Atan2(Target.transform.position.z - transform.position.z, Target.transform.position.x - transform.position.x);
            transform.position += new Vector3(Mathf.Cos(angle) * Speed, 0.0f, Mathf.Sin(angle) * Speed);
        }
    }
}
