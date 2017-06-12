using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;

    private const float speed = 0.0f;

    float angle = 0.0f;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI + (Mathf.PI * 0.5f);
        gameObject.transform.position += new Vector3(Mathf.Cos(angle) * speed, 0.0f, Mathf.Sin(angle) * speed);
        Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f);

        gameObject.transform.position += dir * speed * Time.deltaTime;
    }
}
