using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    //[SerializeField]
    //private string DirectionType;
    public string DirectionType;
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    /// <summary>フォント</summary>
    private GUIStyle labelStyle;



    // Use this for initialization
    void Start()
    {
        //ベクトル初期化
        touchStartPos = new Vector3(0.0f, 0.0f, 0.0f);
        touchEndPos = new Vector3(0.0f, 0.0f, 0.0f);

        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;

    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        //string Direction;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                DirectionType = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                DirectionType = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                DirectionType = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                DirectionType = "down";
            }
        }
        else
        {
            //タッチを検出
            DirectionType = "touch";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //入力検出
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
            GetDirection();
        }
    }

    /// <summary>
    /// GUI更新はここじゃないとダメらしいよ。
    /// まだよくわかんない。
    /// </summary>
    void OnGUI()
    {
        if (DirectionType != null)
        {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;

            string text = string.Empty;
            text = string.Format("Flick:{0}", DirectionType);
            GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
        }
    }
}