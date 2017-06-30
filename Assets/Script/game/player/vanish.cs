using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanish : MonoBehaviour {

    [SerializeField]
    private float vanishDamage = 100.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider col)
    {
        //潰されたらの処理
        if (col.tag == "enemy")
        {
            //Destroy(col.transform.gameObject);
            col.GetComponent<EnemyLife>().SubLife(vanishDamage);
        }

        if (col.tag == "EnemyBoss")
        {
            //Destroy(col.transform.gameObject);
            col.GetComponent<EnemyBossLife>().SubLife(vanishDamage);
        }
    }
}
