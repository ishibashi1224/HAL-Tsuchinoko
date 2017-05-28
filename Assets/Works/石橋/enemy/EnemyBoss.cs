using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject Object = null;
    [SerializeField]
    private GameObject movement = null;
    [SerializeField]
    float OutRadius = 0.0f;
    [SerializeField]
    float InRadius = 0.0f;
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

        if (_Radius <= OutRadius)
        {
            transform.position = Vector3.Lerp(Object.transform.position, transform.position, Speed);

            if(_Radius <= InRadius)
            {
                movement.SetActive(true);
            }
            else
            {
                movement.SetActive(false);
            }
        }
    }
}
