using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 0.01f;
    public int dleateTime = 5;
    private int cntTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
        gameObject.transform.position += new Vector3(Mathf.Sin(angle) * speed, 0.0f, Mathf.Cos(angle) * speed);

        ////デリート
        //cntTime++;
        //if (cntTime > 60)
        //{
        //    cntTime = 0;
        //    dleateTime--;
        //    if (dleateTime == 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
}
