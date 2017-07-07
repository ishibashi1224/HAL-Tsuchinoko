using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaUseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.transform.GetChild(0).
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Canvas").transform.Find("LeftButton").gameObject.SetActive(true);
    }
}
