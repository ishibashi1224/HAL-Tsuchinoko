using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBehavior : EnemyBehavior
{
    [SerializeField]
    private float Wait = 0.0f;
    [SerializeField]
    private bool RotDirection = true;

    private GameObject Target = null;
    private float time = 0.0f;
    //private Vector3 rot;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    public override void Init()
    {
        time = 0.0f;
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
        transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(Target.transform.position.x - transform.root.position.x, Target.transform.position.z - transform.root.position.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);
        //rot = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(Target.transform.position.x - transform.root.position.x, Target.transform.position.z - transform.root.position.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);
    }

    public override bool Execute()
    {
        //transform.root.eulerAngles = Vector3.Lerp(rot, transform.root.eulerAngles, 0.8f);

        if (Wait <= time)
        {
            return false;
        }
        time += Time.deltaTime;

        return true;
    }

    public override void Uninit()
    {

    }
}
