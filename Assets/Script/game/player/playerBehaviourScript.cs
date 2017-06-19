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
    Vector2[] nowPos = new Vector2[3];

    int compileMode;
    bool GameStart = false;
    int artsCnt;

    //テスト用（後で消そう）
    int num = 0;

    void Awake()
    {
        float screenRate = (float)1024 / Screen.height;
        if (screenRate > 1) screenRate = 1;
        int width = (int)(Screen.width * screenRate);
        int height = (int)(Screen.height * screenRate);
        Screen.SetResolution(width, height, true, 15);
        artsCnt = 0;
    }

    // Use this for initialization
    void Start()
    {
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;

#if UNITY_EDITOR_WIN
        compileMode = 0;
#else
        compileMode = 1;
#endif
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y <= 8.0f)
        {
            gameObject.transform.position += new Vector3(0, 0.05f, 0);
        }
        else if( GameStart == false && gameObject.transform.position.z <= 0.0f)
        {
            gameObject.transform.position += new Vector3(0, 0, move);
        }
        else
        {
            if (GameStart == false)
            {
                gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, 0);
                StartPoint();
                GameStart = true;
            }
        }
            
        Arts();

        Move();

        MoveRot();

        rot.eulerAngles = Rot;
        gameObject.transform.rotation = rot;
        gameObject.transform.position += Pos;

        Scaling();

    }

    void StartPoint()
    {
        //angle = 0;
        //transform.GetChild(0).gameObject.transform.position = transform.position - new Vector3(Mathf.Sin(angle) * 5, 0, Mathf.Cos(angle) * 5);

        //transform.GetChild(0).gameObject.transform.position = transform.position - new Vector3(0, 0, 2.5f);

        angle = (240 / 180.0f) * Mathf.PI;
        transform.GetChild(1).gameObject.transform.position = transform.position + new Vector3(Mathf.Sin(angle) * 5, 0, Mathf.Cos(0) * 5);

        angle = (120 / 180.0f) * Mathf.PI;
        transform.GetChild(2).gameObject.transform.position = transform.position + new Vector3(Mathf.Sin(angle) * 5, 0, Mathf.Cos(0) * 5);

        gameObject.transform.GetChild(3).localScale = new Vector3(3.0f, 1.0f, 3.0f);

        //ビット子機の距離計算用変数
        nowPos[1].x = transform.GetChild(1).gameObject.transform.position.x;
        nowPos[1].y = transform.GetChild(1).gameObject.transform.position.z;

        nowPos[2].x = transform.GetChild(2).gameObject.transform.position.x;
        nowPos[2].y = transform.GetChild(2).gameObject.transform.position.z;

        limitLengthMin = Vector2.Distance(nowPos[1], nowPos[2]);
        limitLengthMax = limitLengthMin * 2;

        angle = (330 / 180.0f) * Mathf.PI;
        transform.GetChild(0).gameObject.transform.position = transform.GetChild(1).gameObject.transform.position - new Vector3(Mathf.Sin(angle) * limitLengthMin, 0, Mathf.Cos(angle) * limitLengthMin);

    }

    void Move()
    {
        //移動
        if (compileMode == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    TargetRot.y = -45.0f;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    TargetRot.y = 45.0f;
                }
                else
                {
                    TargetRot.y = 0.0f;
                }
                Pos.x = Mathf.Sin(TargetRot.y) * move;
                Pos.z = Mathf.Cos(TargetRot.y) * move;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    TargetRot.y = -135.0f;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    TargetRot.y = 135.0f;
                }
                else
                {
                    TargetRot.y = 180.0f;
                }
                Pos.x = Mathf.Sin(TargetRot.y) * move;
                Pos.z = Mathf.Cos(TargetRot.y) * move;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                TargetRot.y = -90.0f;
                Pos.x = Mathf.Sin(TargetRot.y) * move;
                Pos.z = Mathf.Cos(TargetRot.y) * move;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                TargetRot.y = 90.0f;
                Pos.x = Mathf.Sin(TargetRot.y) * move;
                Pos.z = Mathf.Cos(TargetRot.y) * move;
            }

        }
        else
        {
            Pos.x = Input.acceleration.x * move;
            Pos.z = Input.acceleration.y * move;

            TargetRot.y = (Mathf.Atan2(Input.acceleration.x, Input.acceleration.y) / Mathf.PI) * 180.0f;
        }
    }

    void MoveRot()
    {
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
    }

    void Scaling()
    {
        //ビット子機の距離計算用変数
        nowPos[1].x = transform.GetChild(1).gameObject.transform.position.x;
        nowPos[1].y = transform.GetChild(1).gameObject.transform.position.z;

        nowPos[2].x = transform.GetChild(2).gameObject.transform.position.x;
        nowPos[2].y = transform.GetChild(2).gameObject.transform.position.z;

        if (Input.GetKey(KeyCode.C))
        {
            if (limitLengthMax >= Vector2.Distance(nowPos[1], nowPos[2]))
            {
                angle = (transform.GetChild(0).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(0).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                angle = (transform.GetChild(2).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(1).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                angle = (transform.GetChild(1).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(2).gameObject.transform.position -= new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                gameObject.transform.GetChild(3).localScale += new Vector3( 0.4f , 0, 0.4f);
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            if (limitLengthMin < Vector2.Distance(nowPos[1], nowPos[2]))
            {
                angle = (transform.GetChild(0).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(0).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                angle = (transform.GetChild(2).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(1).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                angle = (transform.GetChild(1).gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
                transform.GetChild(2).gameObject.transform.position += new Vector3(Mathf.Sin(angle) * ScalingMove, 0.0f, Mathf.Cos(angle) * ScalingMove);

                gameObject.transform.GetChild(3).localScale -= new Vector3(0.4f, 0, 0.4f);
            }
        }

////////スマホ・タッチ用//////////////
        if (Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            if (t2.phase == TouchPhase.Began)
            {
                tuchBegin = Vector2.Distance(t1.position, t2.position);
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                tuchMove = Vector2.Distance(t1.position, t2.position);

                if (tuchBegin < tuchMove)
                {
                    if (limitLengthMax >= Vector2.Distance(nowPos[1], nowPos[2]))
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
                    }
                }
            }
            else
            {
                tuchBegin = Vector2.Distance(t1.position, t2.position);
            }
        }
    }

    void Arts()
    {
        if (gameObject.transform.GetChild(3).gameObject.activeSelf == true )
        {
            artsCnt++;
            if (artsCnt >= 120)
            {
               //transform.GetChild(0).gameObject.transform.position += (transform.position - transform.GetChild(0).gameObject.transform.position) * 0.1f;
                //transform.GetChild(1).gameObject.transform.position += (transform.position - transform.GetChild(1).gameObject.transform.position) * 0.1f;
                //transform.GetChild(2).gameObject.transform.position += (transform.position - transform.GetChild(2).gameObject.transform.position) * 0.1f;

            }
        }
        else
        {
            if(artsCnt > 0)
            {
                //StartPoint();
            }
            artsCnt = 0;
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
