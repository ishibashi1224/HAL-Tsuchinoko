using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviourScript : MonoBehaviour
{
    // PlayerBulletプレハブ
    [SerializeField]
    private float move = 0.0f;
    [SerializeField]
    private float ScalingMove = 0.0f;
    private GUIStyle labelStyle;
    Vector3 Pos;
    Vector3 Rot;
    Quaternion rot;
    Vector3 TargetRot;
    Vector3 NowRot;
    Vector3 RotMove;
    float tuchBegin;
    float tuchMove;
    float angle;
    float limitLengthMin;
    float limitLengthMax;
    Vector2[] defaultPos = new Vector2[3];
    Vector2[] maxPos = new Vector2[3];
    Vector2[] nowPos = new Vector2[3];

    void Awake()
    {
        float screenRate = (float)1024 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
    }

    // Use this for initialization
    void Start()
    {
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;

        defaultPos[0].x = transform.GetChild(0).gameObject.transform.position.x;
        defaultPos[0].y = transform.GetChild(0).gameObject.transform.position.z;

        defaultPos[1].x = transform.GetChild(1).gameObject.transform.position.x;
        defaultPos[1].y = transform.GetChild(1).gameObject.transform.position.z;

        defaultPos[2].x = transform.GetChild(2).gameObject.transform.position.x;
        defaultPos[2].y = transform.GetChild(2).gameObject.transform.position.z;

        nowPos[0] = defaultPos[0];
        nowPos[1] = defaultPos[1];
        nowPos[2] = defaultPos[2];

        limitLengthMin = Vector2.Distance(nowPos[1], nowPos[2]);
        limitLengthMax = limitLengthMin * 7;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Pos.x = Input.acceleration.x * move;
        Pos.z = Input.acceleration.y * move;

        TargetRot.y = (Mathf.Atan2(Input.acceleration.x, Input.acceleration.y) / Mathf.PI) * 180.0f;

        NowRot = gameObject.transform.rotation.eulerAngles;

        if (NowRot.y >= 180.0f)
        {
            NowRot.y = 360.0f - NowRot.y;
            NowRot.y = NowRot.y * -1;
        }

        RotMove.y = TargetRot.y - NowRot.y;

        if (RotMove.y >= 180.0f)
        {
            RotMove.y = RotMove.y - 2 * 180.0f;
        }
        else if (RotMove.y <= -180.0f)
        {
            RotMove.y = 2 * 180.0f + RotMove.y;
        }

        RotMove = RotMove * 0.1f;
        NowRot.y += RotMove.y;

        Rot = new Vector3(gameObject.transform.rotation.eulerAngles.x, NowRot.y, gameObject.transform.rotation.eulerAngles.z);

        rot.eulerAngles = Rot;
        gameObject.transform.rotation = rot;
        gameObject.transform.position += Pos;

        //ビット子機の距離計算用変数
        nowPos[1].x = transform.GetChild(1).gameObject.transform.position.x;
        nowPos[1].y = transform.GetChild(1).gameObject.transform.position.z;

        nowPos[2].x = transform.GetChild(2).gameObject.transform.position.x;
        nowPos[2].y = transform.GetChild(2).gameObject.transform.position.z;

        if (Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            if (t2.phase == TouchPhase.Began)
            {
                tuchBegin = Vector2.Distance(t1.position, t2.position);
            }
            else if(t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                tuchMove = Vector2.Distance(t1.position, t2.position);

                if (tuchBegin < tuchMove)
                {
                    if (limitLengthMax >= Vector2.Distance(nowPos[1], nowPos[2]) )
                    {
                        angle = (transform.GetChild(0).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(0).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                        angle = (transform.GetChild(2).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(1).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                        angle = (transform.GetChild(1).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(2).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);
                    }
                }
                else if (tuchBegin > tuchMove)
                {
                    if (limitLengthMin < Vector2.Distance(nowPos[1], nowPos[2]))
                    {
                        angle = (transform.GetChild(0).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(0).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                        angle = (transform.GetChild(2).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(1).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                        angle = (transform.GetChild(1).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                        transform.GetChild(2).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);
                 
                    //if (limitLengthMin < Vector2.Distance(nowPos[1], nowPos[2]))
                    //{
                    //    transform.GetChild(0).gameObject.transform.position = new Vector3(  defaultPos[0].x,
                    //                                                                        transform.GetChild(0).gameObject.transform.position.y,
                    //                                                                        defaultPos[0].y);
                    //    transform.GetChild(1).gameObject.transform.position = new Vector3(  defaultPos[1].x,
                    //                                                                        transform.GetChild(1).gameObject.transform.position.y,
                    //                                                                        defaultPos[1].y);
                    //    transform.GetChild(2).gameObject.transform.position = new Vector3(  defaultPos[2].x,
                                                                                            //transform.GetChild(2).gameObject.transform.position.y,
                                                                                            //defaultPos[2].y);
                    }
                }
            }
            else
            {
                tuchBegin = Vector2.Distance(t1.position, t2.position);
            }
        }

    }
    /// <summary>
    /// GUI更新はここじゃないとダメらしいよ。
    /// まだよくわかんない。
    /// </summary>
    void OnGUI()
    {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;

        string text = string.Empty;

        text = NowRot.y.ToString();

        GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
    }


}
