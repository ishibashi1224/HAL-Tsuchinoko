using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    //コリジョン
    private void OnTriggerStay(Collider other)
    {
        //名前がbit1又はbit2だった時　かつ　マウスを離した瞬間
        if ((other.gameObject.name == "bit1"|| other.gameObject.name == "bit2") &&
            Input.GetKeyUp(KeyCode.Mouse0) )
        {
            //入れ替えすべき処理
            //transform.position = other.gameObject.transform.position;   //座標補正
            transform.rotation = other.transform.FindChild("bit").rotation;//角度補正
            transform.position = other.transform.FindChild("bit").position;//座標補正
            Destroy(other.gameObject);   //当たったオブジェクト(bit1 || bit2)を消す
        }
    }
}
