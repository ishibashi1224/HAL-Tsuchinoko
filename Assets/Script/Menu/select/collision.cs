using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {
    //private GameObject work;
    private Vector3 work_pos;
    private Transform transform_work;
    [SerializeField]
    private int id = 0;
    // Use this for initialization
    
    void Start () {
        transform_work = this.transform;
        work_pos = transform.position;
        //work = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        work_pos = transform.position;
        //work = gameObject;
    }

    private void SetSphereCollider (GameObject Gameobject)
    {
        Debug.Log(Gameobject.transform.GetChild(0));
        //スフィアコライダー適用
        SphereCollider workcollider = Gameobject.transform.GetChild(0).gameObject.AddComponent<SphereCollider>();
        workcollider.radius = 7;
        workcollider.isTrigger = true;

        //RigitBody適用
        /*Rigidbody workrigitbody = Gameobject.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        workrigitbody.mass = 1.0f;
        workrigitbody.angularDrag = 0;
        workrigitbody.isKinematic = false;
        workrigitbody.useGravity = false;*/
    }

    //コリジョン
    private void OnTriggerStay(Collider other)
    {
        //名前がbit1又はbit2だった時　かつ　マウスを離した瞬間
        if (other.gameObject.tag == "Player"&&
            Input.GetKeyUp(KeyCode.Mouse0))
        {
            //入れ替えすべき処理

            Debug.Log(BitManager.GetBit(id).transform.GetChild(0).gameObject);
            GameObject work = Instantiate(BitManager.GetBit(id).transform.GetChild(0).gameObject, other.transform);
            work.transform.GetChild(0).transform.position = other.transform.GetChild(0).transform.position;

            work.transform.parent = other.transform.parent.transform.parent;//bit1
            work.name = other.transform.parent.name;

            //登録
            BitDataManager.Instance.SetBitID(BitNameTransformNumber(work.name), id);

            SetSphereCollider(work);

            //対象破壊
            Destroy(other.transform.parent.gameObject);                                               //当たったオブジェクト消える
        }
    }
    private int Bitnumber;
    public int BitNameTransformNumber(string name)
    {
        
        switch(name)
        {
            case "bit0":
                Bitnumber = 0;
                break;

            case "bit1":
                Bitnumber = 1;
                break;

            case "bit2":
                Bitnumber = 2;
                break;

            default:
                break;
        } 
        return Bitnumber ;
    }
}
