using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMove : MonoBehaviour {
    //テスト
    private int cnt;

    private Vector3 pos;
    private Vector3 oldpos;

    private bool test_flag = false;
    //描画用
    private GUIStyle labelStyle;

    //Plane
    private GameObject plane = GameObject.Find("Plane");

    // Use this for initialization
    void Start () {
        //テスト
        cnt = 0;
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;
        pos = new Vector3(0.0f, 0.0f, 0.0f);
        oldpos = new Vector3(0.0f, 0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        

        oldpos = pos;
        
        //プレース
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);

           cnt++;
           if (cnt > 60)
           {
                test_flag = true;
                cnt = 0;
           }
        }
       
 


    }

    void OnGUI()
    {
        float x = Screen.width / 10;
        float y = 0;
        float w = Screen.width * 8 / 10;
        float h = Screen.height / 20;

        string text_cnt = string.Empty;
        text_cnt = string.Format("TapDown:{0}", cnt);
        string text_s = string.Empty;
        GUI.Label(new Rect(x, y, w, h), text_cnt, this.labelStyle);
    }
}
