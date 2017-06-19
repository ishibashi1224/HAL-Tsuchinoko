using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBehavior : EnemyBehavior
{
    [SerializeField]
    private float Width = 0.0f;
    [SerializeField]
    private float Height = 0.0f;
    [SerializeField]
    private float Speed = 0.0f;
    [SerializeField]
    private bool RotDirection = true;

    private Vector3 pos, oldPos;
    private float angle;

    public override void Init()
    {
        pos = transform.root.position;
        angle = Mathf.PI * 0.5f;
    }

    public override bool Execute()
    {
        transform.root.position = new Vector3(pos.x + (Mathf.Cos(angle) * Width), pos.y, pos.z + (Mathf.Sin(2 * angle) * Height));
        transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(transform.root.position.x - oldPos.x, transform.root.position.z - oldPos.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);

        if (RotDirection == true)
        {
            angle -= Speed;
            if (angle < -Mathf.PI * 1.5f) return false;
        }
        else
        {
            angle += Speed;
            if (angle > Mathf.PI * 2.5f) return false;
        }

        oldPos = transform.root.position;

        return true;
    }

    public override void Uninit()
    {

    }
}
