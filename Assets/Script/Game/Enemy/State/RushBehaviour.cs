using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBehaviour : EnemyBehavior
{
    [SerializeField]
    private float Speed = 0.0f;
    [SerializeField]
    private float RotSpeed = 0.0f;
    [SerializeField]
    private bool RotDirection = true;

    private Vector3 pos, oldPos;
    private float angle, _angle, radius;
    private bool action;
    private GameObject Target = null;
    private BossArea Area = null;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
        Area = GameObject.FindGameObjectWithTag("Area").GetComponent<BossArea>();
    }

    public override void Init()
    {
        _angle = 0.0f;
        pos = transform.root.position;
        angle = Mathf.Atan2(Target.transform.position.x - transform.root.position.x, Target.transform.position.z - transform.root.position.z);
        action = true;
    }

    public override bool Execute()
    {
        if (action)
        {
            transform.root.position += new Vector3(Mathf.Sin(angle) * Speed, 0.0f, Mathf.Cos(angle) * Speed);

            if (!Area.Detection(transform.position))
            {
                action = false;
                pos = (pos + transform.root.position) * 0.5f;
                pos.y = transform.root.position.y;
                radius = Vector2.Distance(new Vector2(pos.x, pos.z), new Vector2(transform.root.position.x, transform.root.position.z));
            }

            transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, (angle + _angle) * 180 / Mathf.PI, transform.root.eulerAngles.z);
        }
        else
        {
            transform.root.position = new Vector3(pos.x + (Mathf.Sin(angle + _angle) * radius), pos.y, pos.z + (Mathf.Cos(angle + _angle) * radius));
            transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(transform.root.position.x - oldPos.x, transform.root.position.z - oldPos.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);

            if (_angle <= -Mathf.PI || _angle >= Mathf.PI) return false;

            if (RotDirection) _angle += RotSpeed;
            else _angle -= RotSpeed;

            oldPos = transform.root.position;
        }

        

        return true;
    }

    public override void Uninit()
    {

    }
}
