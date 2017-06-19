using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
    
    private GameObject work;
    private Vector3 work_pos;
    private Transform transform_work;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        work_pos = transform.position;
        work = gameObject;
    }

    //コリジョン
    private void OnTriggerStay(Collider other)
    {
        //名前がbit1又はbit2だった時　かつ　マウスを離した瞬間
        if (other.gameObject.tag == "Player"&&
            Input.GetKeyUp(KeyCode.Mouse0))
        {
            //入れ替えすべき処理
            //transform.position = other.gameObject.transform.position;              //座標補正
            GameObject copy = Object.Instantiate(work);                                                //生成
            copy.transform.position = work_pos;
            //work.gameObject.transform.position= work_pos;
            
            transform.rotation = other.transform.rotation;          //角度補正
            transform.position = other.transform.position;          //座標補正
            
            Destroy(other.gameObject);                                               //当たったオブジェクト(bit1 || bit2)を消す
        }
    }
}
