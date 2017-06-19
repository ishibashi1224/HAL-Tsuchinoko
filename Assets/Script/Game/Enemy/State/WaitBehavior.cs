using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBehavior : EnemyBehavior
{
    [SerializeField]
    private GameObject Player = null;
    [SerializeField]
    private float Wait = 0.0f;
    [SerializeField]
    private bool RotDirection = true;

    private float time = 0.0f;
    //private Vector3 rot;

    public override void Init()
    {
        time = 0.0f;
        transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(Player.transform.position.x - transform.root.position.x, Player.transform.position.z - transform.root.position.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);
        //rot = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(Player.transform.position.x - transform.root.position.x, Player.transform.position.z - transform.root.position.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);
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
