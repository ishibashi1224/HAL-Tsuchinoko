using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRot : MonoBehaviour {
    private int number;
    [SerializeField]
    private float rot;
    private float angle = 0;
    // Use this for initialization
    void Start () {
        number = Random.Range(0, 4);
        angle = 0;
    }
   
    // Update is called once per frame
    void Update () {

        angle += rot;
        angle = angle % 360.0f;
        if (number % 2 == 0)
        {
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.up);
        }

    }
}
