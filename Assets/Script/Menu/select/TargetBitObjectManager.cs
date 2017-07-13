using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBitObjectManager : SingletonMonoBehaviourFast<TargetBitObjectManager>
{
    // rayが届く範囲
    public float distance = 100f;
    private static string objname;
    private static bool select = false;
    void Update()
    {
        if (!FadeManager.GetFadeing())
        {
            if (!select)
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
                        //if (hit.transform.gameObject.GetComponent<GrappleObject>())
                        for (int i = 0; i < BitManager.GetLength(); i++)
                        {
                            if (BitManager.GetBit(i).name == hit.transform.name.ToString())
                            {
                                AudioManager.instance.PlaySE("UnitSelect");
                                hit.transform.gameObject.GetComponent<GrappleObject>().SetUse(true);
                                objname = hit.transform.name.ToString();
                                select = true;
                                break;
                            }
                        }
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                select = false;
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
