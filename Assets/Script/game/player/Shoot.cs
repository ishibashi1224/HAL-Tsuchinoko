using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;
    [SerializeField]
    private int dleateTime = 5;
    private int cntTime = 0;

    [SerializeField]
    private int AttackNum = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
       gameObject.transform.position += new Vector3(Mathf.Sin(angle) * speed, 0.0f, Mathf.Cos(angle) * speed);
    }

    public int Atack()
    {
        return AttackNum;
    }
}
