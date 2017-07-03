using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private int cnt = 0;
    private int WaitFrame = 0;
    private bool WaitFlag = false;
    private bool Use= false;
    private Vector3 TargetObjectPosition;
    private float rate = 1.0f;
    private Vector3 scl;

    [SerializeField]
    private int GrappleCntFlam = 0;                //物を掴むまでのフレーム数(プレースフレーム数)

    [SerializeField]
    private static bool ObjectPick = false;   //物を掴んでいるフラグ

    [SerializeField]
    float SclRate;
    //[SerializeField]
    //private int TargetWaitFrame = 0;

    private void Start()
    {
        ObjectPick = false;
        cnt = 0;
        TargetObjectPosition = transform.position;
        WaitFlag = false;
        Use = false;
        scl = transform.localScale;
    }

    private void Update()
    {
        if (Use)
        {
            if (ObjectPick)
            {
                this.transform.localScale += new Vector3(this.transform.localScale.x + 0.001f, this.transform.localScale.y, this.transform.localScale.z + 0.001f);
                if (this.transform.localScale.x >= scl.x * SclRate)
                {
                    this.transform.localScale = new Vector3(scl.x * SclRate, scl.y, scl.z * SclRate);
                }

            }
            else
            {
                this.transform.localScale = scl;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                cnt++;
                if (cnt > GrappleCntFlam)
                {
                    Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
                    ObjectPick = true;
                    transform.position = currentPosition;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                cnt = 0;
                transform.position = TargetObjectPosition;
                WaitFlag = true;
                //Destroy(this.transform.gameObject.GetComponent<GrappleObject>());
            }
            else if (WaitFlag)
            {
                /*WaitFrame++;
                if (WaitFrame > TargetWaitFrame)
                {*/
                    ObjectPick = false;
                    WaitFlag = false;
                    //WaitFrame = 0;
                    Use = false;
                //}
            }

            if (ObjectPick)
            {
                this.transform.localScale += new Vector3(this.transform.localScale.x + 0.001f, this.transform.localScale.y, this.transform.localScale.z + 0.001f);
                if (this.transform.localScale.x >= scl.x * SclRate)
                {
                    this.transform.localScale = new Vector3(scl.x * SclRate, scl.y, scl.z * SclRate);
                }

            }
            else
            {
                this.transform.localScale = scl;
            }
        }
    }

    void OnMouseDown()
    {
        // マウスカーソルは、スクリーン座標なので、
        // 対象のオブジェクトもスクリーン座標に変換してから計算する。

        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    //物を掴んでいるフラグ取得メソッド
    public static  bool GetFlag()
    {
        return ObjectPick;
    }
    //使用フラグ
    public void SetUse (bool use)
    {
        Use = use;
    }
}
