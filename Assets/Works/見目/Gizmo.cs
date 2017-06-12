using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

    public float gizmoSize = 0.3f;
    public Color gizmoColor = Color.yellow;


    // Use this for initialization
    void Start () {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
