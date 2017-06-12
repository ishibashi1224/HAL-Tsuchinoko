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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= interval)
        {
            tes = Quaternion.identity;
            tes.y = 90;
            Instantiate(bullet, transform.position, transform.rotation * transform.localRotation);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
