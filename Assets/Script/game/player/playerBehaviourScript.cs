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

    Vector3[] defaultLocalPos = new Vector3[3];

    float playerSize;

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

        //テクスチャの高さ取得
        playerSize = transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().bounds.extents.z;
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

        if (GameStart == false)
        {
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, 0);
            StartPoint();
            GameStart = true;
        }

        Arts();

        Move();

        MoveRot();

        rot.eulerAngles = Rot;
        gameObject.transform.rotation = rot;
        gameObject.transform.position += Pos;
        if (gameObject.transform.GetChild(3).gameObject.activeSelf == false)
        {
            Scaling();
        }

        //gaemeOver();
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

        gameObject.transform.GetChild(3).localScale = new Vector3(1.2f, 1.0f, 1.2f);
        gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //ビット子機の距離計算用変数
        nowPos[1].x = transform.GetChild(1).gameObject.transform.position.x;
        nowPos[1].y = transform.GetChild(1).gameObject.transform.position.z;

        nowPos[2].x = transform.GetChild(2).gameObject.transform.position.x;
        nowPos[2].y = transform.GetChild(2).gameObject.transform.position.z;

        limitLengthMin = Vector2.Distance(nowPos[1], nowPos[2]);
        limitLengthMax = limitLengthMin * 3;

        angle = (330 / 180.0f) * Mathf.PI;
        transform.GetChild(0).gameObject.transform.position = transform.GetChild(1).gameObject.transform.position - new Vector3(Mathf.Sin(angle) * limitLengthMin, 0, Mathf.Cos(angle) * limitLengthMin);

        gameObject.transform.GetChild(1).transform.GetChild(0).eulerAngles = new Vector3(0.0f, 120.0f, 0.0f);
        gameObject.transform.GetChild(2).transform.GetChild(0).eulerAngles = new Vector3(0.0f, 240.0f, 0.0f);
        defaultLocalPos[0] = transform.GetChild(0).gameObject.transform.localPosition;
        defaultLocalPos[1] = transform.GetChild(1).gameObject.transform.localPosition;
        defaultLocalPos[2] = transform.GetChild(2).gameObject.transform.localPosition;

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

        //回転度合
        RotMove = RotMove * 0.025f;

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

                //gameObject.transform.GetChild(3).localScale += new Vector3(0.2f, 0, 0.2f);
                //gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).localScale -= new Vector3(0.04f, 0.0f, 0.04f);
                transform.gameObject.GetComponent<Arts>().nowScale(new Vector3(+0.33f * ScalingMove , 0, +0.33f * ScalingMove));
            }

            defaultLocalPos[0] = transform.GetChild(0).gameObject.transform.localPosition;
            defaultLocalPos[1] = transform.GetChild(1).gameObject.transform.localPosition;
            defaultLocalPos[2] = transform.GetChild(2).gameObject.transform.localPosition;
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

                //gameObject.transform.GetChild(3).localScale -= new Vector3(0.2f, 0, 0.2f);
                //gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).localScale += new Vector3(0.04f, 0.0f, 0.04f);
                transform.gameObject.GetComponent<Arts>().nowScale(new Vector3(-0.33f * ScalingMove, 0, -0.33f * ScalingMove));
            }
            defaultLocalPos[0] = transform.GetChild(0).gameObject.transform.localPosition;
            defaultLocalPos[1] = transform.GetChild(1).gameObject.transform.localPosition;
            defaultLocalPos[2] = transform.GetChild(2).gameObject.transform.localPosition;
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

                        transform.gameObject.GetComponent<Arts>().nowScale(new Vector3(+0.33f * ScalingMove, 0, +0.33f * ScalingMove));
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

                        transform.gameObject.GetComponent<Arts>().nowScale(new Vector3(-0.33f * ScalingMove, 0, -0.33f * ScalingMove));
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
        if (gameObject.transform.GetChild(3).gameObject.activeSelf == true)
        {
            Vector3 buf;//計算用
            //artsCnt++;
            if (transform.gameObject.GetComponent<Arts>().nowAnim() == 0)
            {
                buf = new Vector3(0.0f, 0.0f, 0.0f);
                transform.GetChild(0).gameObject.transform.localPosition += (buf - transform.GetChild(0).gameObject.transform.localPosition) * 0.05f;

                buf = new Vector3( -1.3f, 0.0f,  2.5f);
                transform.GetChild(1).gameObject.transform.localPosition += (buf - transform.GetChild(1).gameObject.transform.localPosition) * 0.05f;

                buf = new Vector3( 1.3f, 0.0f, 2.5f);
                transform.GetChild(2).gameObject.transform.localPosition += (buf - transform.GetChild(2).gameObject.transform.localPosition) * 0.05f;
            }
        }
        else
        {
            //buf = new Vector3(0.0f, 0.0f, 0.0f);
            transform.GetChild(0).gameObject.transform.localPosition += (defaultLocalPos[0] - transform.GetChild(0).gameObject.transform.localPosition) * 0.1f;

            //buf = new Vector3(-1.3f, 0.0f, 2.5f);
            transform.GetChild(1).gameObject.transform.localPosition += (defaultLocalPos[1] - transform.GetChild(1).gameObject.transform.localPosition) * 0.1f;

            //buf = new Vector3(1.3f, 0.0f, 2.5f);
            transform.GetChild(2).gameObject.transform.localPosition += (defaultLocalPos[2] - transform.GetChild(2).gameObject.transform.localPosition) * 0.1f;
            artsCnt = 0;
        }
    }

    void gaemeOver()
    {
        if (gameObject.transform.GetChild(0).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == false
            && gameObject.transform.GetChild(0).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == false
            && gameObject.transform.GetChild(0).GetChild(0).GetComponent<BitLife>().lifeTrueFalse() == false )
        {
            transform.gameObject.SetActive(false);
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
