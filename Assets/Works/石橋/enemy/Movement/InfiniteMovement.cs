using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMovement : MonoBehaviour
{
    [SerializeField]
    private float width = 0.0f;
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
        angle = Mathf.PI * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.root.position = new Vector3(pos.x + (Mathf.Cos(angle) * width), pos.y, pos.z + (Mathf.Sin(2 * angle) * height));
        angle += speed;

        if (angle > Mathf.PI * 2.5f)
        {
            angle = 0.0f;
            gameObject.SetActive(false);
        }
    }
}
