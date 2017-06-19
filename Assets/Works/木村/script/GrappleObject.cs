using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    int cnt = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            cnt++;
            if (cnt > 100)
            {
                Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
                transform.position = currentPosition;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            cnt = 0;
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
}
