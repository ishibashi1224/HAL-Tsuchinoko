using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitLife : MonoBehaviour {

    [SerializeField]
    private int Life;

    [SerializeField]
    private int CntLife;

    [SerializeField]
    private int reverseTime = 10;

    private float time = 0;
    private int Cnttime = 0;

    private Color DefaultColor;
    private Color nowColor;
    private Color FalseColor = new Color(0.8f, 0.8f, 0.8f);

    // Use this for initialization
    void Start () {
        CntLife = Life;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        DefaultColor = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
        nowColor = DefaultColor;
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        
        if( time >= 60 )
        {
            time = 0.0f;
            Cnttime++;
            nowColor += (DefaultColor - FalseColor) / reverseTime;
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", nowColor);
            if (Cnttime >= reverseTime)
            {
                CntLife = Life;
                gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", DefaultColor);
                nowColor = DefaultColor;
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
            CntLife -= (int)hp;
            if (CntLife > 0)
            {
                nowColor -= (DefaultColor - FalseColor) / Life;
                gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", nowColor);
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
