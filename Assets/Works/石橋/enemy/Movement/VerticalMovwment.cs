using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovwment : MonoBehaviour {

    [SerializeField]
    private float height = 0.0f;
    [SerializeField]
    private float speed = 0.0f;

    private Vector3 pos;
    private float angle;

    // Use this for initialization
    void Start()
    {
        pos = transform.root.position;
        angle = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.root.position = new Vector3(pos.x, pos.y, pos.z + (Mathf.Sin(angle) * height));
        //transform.root.position += new Vector3(0.0f, 0.0f, Mathf.Sin(angle) * height);
        angle += speed;

        //transform.root.position += Vector3.Normalize((transform.root.position + new Vector3(0.0f, 0.0f, Mathf.Cos(angle) * height)) - transform.root.position);
        //angle += speed;

        if (angle > Mathf.PI * 2)
        {
            angle = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
