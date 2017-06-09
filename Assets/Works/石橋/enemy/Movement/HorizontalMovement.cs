using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField]
    private float width = 0.0f;
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
        transform.root.position = new Vector3(pos.x + (Mathf.Sin(angle) * width), pos.y, pos.z);
        angle += speed;

        if (angle > Mathf.PI * 2)
        {
            angle = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
