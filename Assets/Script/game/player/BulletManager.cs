using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet = null;

    [SerializeField]
    private float interval = 0.0f;
    private float time = 0.0f;
    private Quaternion tes;

    [SerializeField]
    private int BulletLimit = 20;

    private int childCnt = 0;

    // Use this for initialization
    void Start()
    {
        for( int i = 0; i < BulletLimit; i++ )
        {
            Instantiate(bullet, transform.position, transform.rotation ).transform.parent = transform;
            transform.GetChild(1 + i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time >= interval)
        {
            childCnt++;
            tes = Quaternion.identity;
            tes.y = 90;

            if (childCnt >= BulletLimit)
            {
                childCnt = 0;
            }

            //Instantiate(bullet, transform.position, transform.rotation * transform.localRotation).transform.parent = transform;
            if (transform.GetChild(1 + childCnt).gameObject.activeSelf == false )
            {
                transform.GetChild(1 + childCnt).gameObject.SetActive(true);
                transform.GetChild(1 + childCnt).gameObject.transform.position = transform.position;
                transform.GetChild(1 + childCnt).gameObject.transform.rotation = transform.rotation * transform.localRotation;
            }

            time = 0;
        }
        time += Time.deltaTime;
    }
}
