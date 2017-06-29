using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceGetter : MonoBehaviour {
    private static Vector3 workpos;
     
	// Use this for initialization
	void Start () {
        workpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Vector3 GetPos()
    {
        return workpos;
    } 
}
