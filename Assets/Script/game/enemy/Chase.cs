using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    float Radius = 0.0f;
    [SerializeField]
    float Speed = 0.0f;
    [SerializeField]
    private float RotSpeed;

    private GameObject Target = null;
    private Quaternion Angle;
    private float angle;
   

    // Use this for initialization

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _Radius = Vector3.Distance(Target.transform.position, transform.position);
        angle = Mathf.Atan2(Target.transform.position.z - transform.position.z, Target.transform.position.x - transform.position.x);
        Angle = Quaternion.Euler(new Vector3(0, (((Mathf.PI - angle) - Mathf.PI * 0.5f) / Mathf.PI) * 180.0f, 0));
        transform.rotation = Quaternion.Lerp(Angle, transform.rotation, RotSpeed);

        if (_Radius <= Radius)
        {
            float rot = ((180.0f - transform.eulerAngles.y) / 180.0f) * Mathf.PI - (Mathf.PI * 0.5f);
            transform.position += new Vector3(Mathf.Cos(rot) * Speed, 0.0f, Mathf.Sin(rot) * Speed);
        }
    }
}
