using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitChange : SingletonMonoBehaviourFast<BitChange>
{
    private int[] bit = new int[3];

	// Use this for initialization
	void Start () {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BitNum( int num , int ID )
    {
        bit[num] = ID;
    }

    public int BitLoad( int num )
    {
        ////テスト
        //bit[0] = 1;
        //bit[1] = 1;
        //bit[2] = 1;
        return bit[num];
    }
}
