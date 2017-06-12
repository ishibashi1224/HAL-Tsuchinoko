using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeshot : MonoBehaviour
{ 
    [SerializeField]
    private GameObject Plasma = null;

    float stepTime;
    float fpsRatio;

    Vector3 posA = new Vector3(2, 0, 0);    //ブラックホールの中心

    Vector3 distance;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        stepTime = Time.deltaTime;
        fpsRatio = Time.deltaTime * 60.0f;    //1以上という場合はUpdate()処理が遅れているという事

        //unityは秒間60フレームで動作している　　Update()は１秒間に60回呼ばれる為
        //Time.deltaTime は 0.0165～ ぐらいになる　Time.deltaTime*60.0f　するとほぼ　１　になる

        distance = posA - Plasma.transform.position;

        distance *= 0.25f;    //最初が最大速度で徐々に遅く小さくなっていく
        float min = 0.01f;    //最小速度＆距離
        float max = 0.4f;    //最大速度＆距離

        //distanceが常に自分の位置に対して加算されるなら「distance.magnitude」は「スピード（時速）」とも言える
        if (distance.magnitude < min)
        {
            Plasma.transform.position = posA;    //完全吸着
        }
        else
        {
            if (distance.magnitude > max)
            {
                distance *= max / distance.magnitude;    //速度を制限する（最大速度以上だせなくなる（一回分の移動距離も小さくなる））
            }
            Plasma.transform.position += distance * fpsRatio;             //ブラックホールの中心に向かって一直線に進む
        }
    }
}
