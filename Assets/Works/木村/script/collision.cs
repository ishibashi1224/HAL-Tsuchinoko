using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
    private GameObject work;
    private Vector3 work_pos;
    private Transform transform_work;
    // Use this for initialization
    void Start () {
        work_pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        work_pos = transform.position;
        //work = gameObject;
    }

    //コリジョン
    private void OnTriggerStay(Collider other)
    {
        //名前がbit1又はbit2だった時　かつ　マウスを離した瞬間
        if (other.gameObject.tag == "Player"&&
            Input.GetKeyUp(KeyCode.Mouse0))
        {
            //入れ替えすべき処理
            //other.gameObject = 
            //other.transform.GetChild(0) = this.transform.FindChild("BitNumber/Bit");


            //自己破壊
            Destroy(this.gameObject);                                               //当たったオブジェクト(bit1 || bit2)を消す

        }
    }
}
