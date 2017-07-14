using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionBullet : MonoBehaviour {

    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private int dleateTime = 5;
    private int cntTime = 0;

    [SerializeField]
    private int AttackNum = 0;

    private float angle;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
        gameObject.transform.position += new Vector3(Mathf.Sin(angle) * speed, 0.0f, Mathf.Cos(angle) * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy" || col.tag == "BossLife")
        {
        }
    }
}
