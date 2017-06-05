using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitLife : MonoBehaviour {

    [SerializeField]
    private int Life;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Life <= 0)
        {
            //Destroy(gameObject);
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color( 0.8f , 0.8f , 0.8f ));
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            Life--;
        }
    }
}
