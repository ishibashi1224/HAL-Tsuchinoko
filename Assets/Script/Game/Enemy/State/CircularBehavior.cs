using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularBehavior : EnemyBehavior
{
    [SerializeField]
    private float radius = 0.0f;
    [SerializeField]
    private float speed = 0.0f;

    private Vector3 pos;
    private float angle;
    
    public override void Init()
    {
        pos = transform.root.position;
        angle = 0.0f;
    }
    
    public override bool Execute()
    {
        transform.root.position = new Vector3(pos.x + (Mathf.Sin(angle) * radius), pos.y, pos.z + (Mathf.Cos(angle) * radius));
        angle += speed;

        if (angle > Mathf.PI * 2)
        {
            angle = 0.0f;
            return false;
        }

        return true;
    }

    public override void Uninit()
    {
        
    }
}
