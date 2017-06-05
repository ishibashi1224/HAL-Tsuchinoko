using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCheck : MonoBehaviour
{

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    private GUIStyle labelStyle;

    // Use this for initialization
    void Start()
    {
        //座標初期化
        touchStartPos = new Vector3(0, 0, 0);
        touchEndPos = new Vector3(0, 0, 0);

        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }
    }



    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 0;
        float y_2 = 0;

        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        for (int i = 0; i < 3; i++)
        {
            y = Screen.height / 10 + h * i;
            y_2 = Screen.height / 4 + h * i;
            
            string text_s = string.Empty;
            string text_e = string.Empty;
            
            switch (i)
            {
                //case 0://X
                //    text_s = string.Format("touchStartPos-X:{0}", System.Math.Round(this.touchStartPos.x, 3));
                //    text_e = string.Format("touchEndPos-X:{0}", System.Math.Round(this.touchEndPos.x, 3));
                //    break;
                //case 1://Y
                //    text_s = string.Format("touchStartPos-Y:{0}", System.Math.Round(this.touchStartPos.y, 3));
                //    text_e = string.Format("touchEndPos-Y:{0}", System.Math.Round(this.touchEndPos.y, 3));
                //    break;
                //case 2://Z
                //    text_s = string.Format("touchStartPos-Z:{0}", System.Math.Round(this.touchStartPos.z, 3));
                //    text_e = string.Format("touchEndPos-Z:{0}", System.Math.Round(this.touchEndPos.z, 3));
                //    break;
                //default:
                //    throw new System.InvalidOperationException();
            }
            GUI.Label(new Rect(x, y, w, h), text_s, this.labelStyle);
            GUI.Label(new Rect(x, y_2, w, h), text_e, this.labelStyle);
        }
    }
}
