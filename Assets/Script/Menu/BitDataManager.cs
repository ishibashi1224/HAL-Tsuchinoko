using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BitDataManager : SingletonMonoBehaviourFast<BitDataManager>
{
    private int[] idx = new int[3];
	// Use this for initialization
	void Start () {
        for(int i = 0; i < 3; i++)
        {
            idx[i] = 0; 
        }        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool SetBitID(int BitNumber, int id)
    {
        idx[BitNumber] = id;
        return true;   
    }

    public void BitSave()
    {
        StreamWriter sw = new StreamWriter("./Assets/Resources/BitData/PlayerBitData.txt", false); //false=上書き
        sw.WriteLine(idx[0].ToString());
        sw.WriteLine(idx[1].ToString());
        sw.WriteLine(idx[2].ToString());
        sw.Flush();
        sw.Close();
    }
}
