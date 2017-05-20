using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 0.01f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI + (Mathf.PI * 0.5f);
        gameObject.transform.position += new Vector3(Mathf.Cos(angle) * speed, 0.0f, Mathf.Sin(angle) * speed);
    }
}
