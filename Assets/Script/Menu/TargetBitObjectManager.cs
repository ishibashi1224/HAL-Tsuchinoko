using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBitObjectManager : SingletonMonoBehaviourFast<TargetBitObjectManager>
{
    // rayが届く範囲
    public float distance = 100f;
    private static string objname;
    void Update()
    {
        // 左クリックを取得
        if (Input.GetMouseButtonDown(0))
        {
            // クリックしたスクリーン座標をrayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Rayの当たったオブジェクトの情報を格納する
            RaycastHit hit = new RaycastHit();
            // オブジェクトにrayが当たった時
            if (Physics.Raycast(ray, out hit, distance))
            {
                hit.transform.gameObject.GetComponent<GrappleObject>().SetUse(true);
                objname = hit.transform.name.ToString();
                Debug.Log(hit.transform.name);
            }
        }
    }

    public static string GetTapName()
    {
        string str = objname;
        objname = "";
        return str;
        
    }
}
