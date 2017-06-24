using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(gameObject.transform.position.y >= 0.1f)
        {
            //gameObject.transform.position -= new Vector3(0, 0.1f, 0);
            //gameObject.transform.localScale+= new Vector3(0.2f, 0, 0.2f);
        }
	}
}
