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

    [SerializeField]
    private int GrappleCntFlam = 50;                //物を掴むまでのフレーム数(プレースフレーム数)

    [SerializeField]
    private static bool ObjectPick = false;   //物を掴んでいるフラグ

    [SerializeField]
    private int TargetWaitFrame = 25;

    private void Start()
    {
        ObjectPick = false;
        cnt = 0;
        TargetObjectPosition = transform.position;
        WaitFlag = false;
        Use = false;
    }

    private void Update()
    {
        if (Use)
        {

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
                WaitFrame++;
                if (WaitFrame > TargetWaitFrame)
                {
                    ObjectPick = false;
                    WaitFlag = false;
                    WaitFrame = 0;
                    Use = false;
                }
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
