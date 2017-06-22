using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBehavior : EnemyBehavior
{
    [SerializeField]
    private int MoveMax = 0;
    [SerializeField]
    private float Speed = 0.0f;
    [SerializeField]
    private float Width = 0.0f;
    [SerializeField]
    private float RotSpeed = 0.0f;
    [SerializeField]
    private bool RotDirection = true;

    private Root Root = null;
    private Vector3 pos, _pos, distancePos, oldPos;     //直線移動用座標・蛇行用座標・判定用座標・前回の座標
    private int point, _point;  //初期地点・初期地点からの移動数
    private int number;         //pointと_pointの合計をRoot.Listの数に合わせた値
    private float angle, _angle, Length;

    private void Awake()
    {
        Root = GameObject.FindGameObjectWithTag("Root").GetComponent<Root>();
    }
    public override void Init()
    {
        pos = transform.root.position;
        point = InitialPoint(pos);
        _point = 0;
        _angle = 0;

        number = DecisionPoint(point, _point);

        angle = Mathf.Atan2(Root.List[number].transform.position.x - pos.x, Root.List[number].transform.position.z - pos.z);
        Length = Distance(Root.List[number].transform.position, pos);
        distancePos = pos;
        oldPos = pos;
    }

    public override bool Execute()
    {
        pos += new Vector3(Mathf.Sin(angle) * Speed, 0.0f, Mathf.Cos(angle) * Speed);
        _pos = new Vector3(Mathf.Sin(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width), 0.0f, Mathf.Cos(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width));
        _angle += RotSpeed;

        if (Distance(distancePos, pos) >= Length)
        {
            //transform.root.position = Root.List[number].transform.position;
            _point = RotDirection == true ? _point + 1 : _point - 1;

            number = DecisionPoint(point, _point);
            angle = Mathf.Atan2(Root.List[number].transform.position.x - pos.x, Root.List[number].transform.position.z - pos.z);
            Length = Distance(Root.List[number].transform.position, pos);
            distancePos = pos;
            _angle = 0;
        }
        else
        {
            transform.root.position = pos + _pos;
        }

        transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, Mathf.Atan2(transform.root.position.x - oldPos.x, transform.root.position.z - oldPos.z) * 180 / Mathf.PI, transform.root.eulerAngles.z);

        oldPos = transform.root.position;

        return ReachingPoint(RotDirection, _point);
    }

    //現在地点を算出
    private int DecisionPoint(int Point, int _Point)
    {
        int num = 0;
        num = (Point + _Point) % Root.List.Count;
        if (num < 0) num = Root.List.Count + num;
        return num;
    }

    //初期地点の算出
    private int InitialPoint(Vector3 Pos)
    {
        int num = 0;
        float Length = 0, _Length = 0;
        for (int count = 0; count < Root.List.Count; count++)
        {
            Length = Vector2.Distance(new Vector2(Root.List[count].transform.position.x, Root.List[count].transform.position.z), new Vector2(Pos.x, Pos.z));
            if (_Length > Length || count == 0)
            {
                _Length = Length;
                num = count;
            }
        }

        return num;
    }

    //指定された地点に到達したか
    private bool ReachingPoint(bool Direction, int Point)
    {
        if (Direction == true)
        {
            if (Point > MoveMax) return false;
        }
        else
        {
            if (Point < -MoveMax) return false;
        }

        return true;
    }

    //Vector3をVector2に直し値を返す
    private float Distance(Vector3 Pos, Vector3 _Pos)
    {
        return Vector2.Distance(new Vector2(Pos.x, Pos.z), new Vector2(_Pos.x, _Pos.z));
    }

    //[SerializeField]
    //private Root Root = null;
    //[SerializeField]
    //private int MoveMax = 0;
    //[SerializeField]
    //private float Speed = 0.0f;
    //[SerializeField]
    //private float Width = 0.0f;
    //[SerializeField]
    //private float RotSpeed = 0.0f;
    //[SerializeField]
    //private bool RotDirection = true;

    //private Vector3 pos, _pos;
    //private int point, num, number;
    //private float angle, _angle, Distance;

    //public override void Init()
    //{
    //    pos = transform.root.position;
    //    point = 0;
    //    float Length = 0, _Length = 0;
    //    for (int count = 0; count < Root.List.Count; count++)
    //    {
    //        Length = Vector2.Distance(new Vector2(Root.List[count].transform.position.x, Root.List[count].transform.position.z), new Vector2(pos.x, pos.z));
    //        if (_Length > Length || count == 0)
    //        {
    //            _Length = Length;
    //            num = count;
    //        }
    //    }

    //    _angle = 0;

    //    pos = transform.root.position;
    //    number = (num + point) % Root.List.Count;
    //    if (number < 0) number = Root.List.Count + number;
    //    angle = Mathf.Atan2(Root.List[number].transform.position.x - pos.x, Root.List[number].transform.position.z - pos.z);

    //    Distance = Vector2.Distance(new Vector2(Root.List[number].transform.position.x, Root.List[number].transform.position.z), new Vector2(pos.x, pos.z));
    //}

    //public override bool Execute()
    //{
    //    pos += new Vector3(Mathf.Sin(angle) * Speed, 0.0f, Mathf.Cos(angle) * Speed);

    //    _pos = new Vector3(Mathf.Sin(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width), 0.0f, Mathf.Cos(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width));
    //    _angle += RotSpeed;

    //    transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, angle * 180 / Mathf.PI, transform.root.eulerAngles.z);
    //    //transform.root.eulerAngles = Vector3.Lerp(new Vector3(transform.root.eulerAngles.x, angle * 180 / Mathf.PI, transform.root.eulerAngles.z), transform.root.eulerAngles, 0.8f);

    //    if (Vector2.Distance(new Vector2(Root.List[number].transform.position.x, Root.List[number].transform.position.z), new Vector2(pos.x, pos.z)) < 0.15f)
    //    {
    //        pos = Root.List[number].transform.position;
    //        point = RotDirection == true ? point + 1 : point - 1;

    //        number = (num + point) % Root.List.Count;
    //        if (number < 0) number = Root.List.Count + number;
    //        angle = Mathf.Atan2(Root.List[number].transform.position.x - pos.x, Root.List[number].transform.position.z - pos.z);
    //    }
    //    else
    //    {
    //        transform.root.position = pos + _pos;
    //    }

    //    if (RotDirection == true)
    //    {
    //        if (point > MoveMax) return false;
    //    }
    //    else
    //    {
    //        if (point < -MoveMax) return false;
    //    }

    //    return true;
    //}

    //public override bool Execute()
    //{
    //    pos = transform.root.position;
    //    int count = (num + point) % Root.List.Count;
    //    if (count < 0) count = Root.List.Count + count;
    //    float angle = Mathf.Atan2(Root.List[count].transform.position.x - pos.x, Root.List[count].transform.position.z - pos.z);
    //    pos += new Vector3(Mathf.Sin(angle) * Speed, 0.0f, Mathf.Cos(angle) * Speed);

    //    pos = pos + new Vector3(Mathf.Sin(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width), 0.0f, Mathf.Cos(angle + (Mathf.PI * 0.5f)) * (Mathf.Sin(_angle) * Width));
    //    _angle += RotSpeed;

    //    transform.root.eulerAngles = new Vector3(transform.root.eulerAngles.x, angle * 180 / Mathf.PI, transform.root.eulerAngles.z);
    //    //transform.root.eulerAngles = Vector3.Lerp(new Vector3(transform.root.eulerAngles.x, angle * 180 / Mathf.PI, transform.root.eulerAngles.z), transform.root.eulerAngles, 0.8f);

    //    if (Vector2.Distance(new Vector2(Root.List[count].transform.position.x, Root.List[count].transform.position.z), new Vector2(pos.x, pos.z)) < 0.1f)
    //    {
    //        transform.root.position = Root.List[count].transform.position;
    //        point = RotDirection == true ? point + 1 : point - 1;
    //    }
    //    else
    //    {
    //        transform.root.position = pos;
    //    }

    //    if (RotDirection == true)
    //    {
    //        if (point > MoveMax) return false;
    //    }
    //    else
    //    {
    //        if (point < -MoveMax) return false;
    //    }

    //    return true;
    //}

    public override void Uninit()
    {
        transform.root.position = pos;
    }
}
