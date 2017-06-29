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
            //other.gameObject = 
            //other.transform.GetChild(0) = this.transform.FindChild("BitNumber/Bit");
            //work = Instantiate(this.gameObject, transform_work);
            //BitManager.SetBit(0, this.gameObject);
            //work.transform = transform_work;
            //transform.Find("BitManager").GetComponent<BitManager>().SetBit(0,);
            //Instantiate(transform.Find("BitManager").GetComponent<BitManager>().GetBit(0), transform_work);
            
            GameObject work = Instantiate(BitManager.GetBit(id).transform.GetChild(0).gameObject, other.transform);

            //work.transform.root.parent = null;
           // work. = work.transform.GetChild(0).GetChild(0).transform;
            work.transform.parent = other.transform.parent.transform.parent;//bit1
            work.name = other.transform.parent.name;

            SetSphereCollider(work);

            //Destroy()
            //対象破壊
            Destroy(other.transform.parent.gameObject);                                               //当たったオブジェクト(bit1 || bit2)を消す

        }
    }
}
