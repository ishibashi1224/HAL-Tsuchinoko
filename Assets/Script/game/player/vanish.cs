using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "enemy")
        {
            Destroy(col.transform.gameObject);
        }
    }
}
