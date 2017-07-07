using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "enemy")
    //    {
    //        col.transform.position += (transform.position - col.transform.position ) * 0.5f;
    //    }
    //}

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "enemy")
        {
            col.transform.position += ( transform.position - col.transform.position) * 0.07f;
        }
    }
}
