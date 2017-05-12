using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float move = 0.0f;
    private GUIStyle labelStyle;
    Vector3 Pos;
    Vector3 Rot;
    Quaternion rot;
    Vector3 TargetRot;
    Vector3 NowRot;
    Vector3 test;

    // Use this for initialization
    void Start()
    {
        //フォント生成
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Pos.x = Input.acceleration.x * move;
        Pos.z = Input.acceleration.y * move;

        TargetRot.y = (Mathf.Atan2(Input.acceleration.x, Input.acceleration.y) / Mathf.PI) * 180.0f;

        NowRot = gameObject.transform.rotation.eulerAngles;

        //NowRot.y = NowRot.y ;
        //NowRot.y = NowRot.y * -1;

        //NowRot.y += (TargetRot.y - NowRot.y) * 0.1f;

        test = Vector3.Lerp(NowRot, TargetRot, 0.1f);

        Rot = new Vector3(gameObject.transform.rotation.eulerAngles.x, test.y, gameObject.transform.rotation.eulerAngles.z);

        rot.eulerAngles = Rot;
        gameObject.transform.rotation = rot;
        gameObject.transform.position += Pos;
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
