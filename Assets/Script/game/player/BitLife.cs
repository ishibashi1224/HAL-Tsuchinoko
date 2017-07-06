using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BitLife : MonoBehaviour {

    [SerializeField]
    private float Life = 10.0f;

    [SerializeField]
    private float CntLife;

    [SerializeField]
    private int reverseTime = 10;

    private float time = 0;
    private int Cnttime = 0;

    private Material material = null;

    // Use this for initialization
    void Start () {
        CntLife = Life;
        if(SceneManager.GetActiveScene().name == "Game")//エラー防止用、ゲームシーンでのみ
        {
            material = gameObject.GetComponent<Renderer>().materials[1];
        }
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        
        if( time >= 60 )
        {
            time = 0.0f;
            Cnttime++;
            if (SceneManager.GetActiveScene().name == "Game")//エラー防止用、ゲームシーンでのみ
            {
                material.SetFloat("_Range", Cnttime / Life);
            }
            if (Cnttime >= reverseTime)
            {
                CntLife = Life;
                Cnttime = 0;
            }
        }
		if(CntLife <= 0)
        {
            time++;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        float hp = 0;
        if (AttackerList.Instance.GetEnemyAttack(col.tag, ref hp))
        {
            CntLife -= hp;
            if (CntLife > 0)
            {
                material.SetFloat("_Range", CntLife / Life);
            }
        }
    }

    public bool lifeTrueFalse()
    {
        if (CntLife <= 0)
        {
            return false;
        }
        return true;
    }
}
