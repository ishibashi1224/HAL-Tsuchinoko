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
        //#if UNITY_EDITOR_WIN
        //        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/BitData/PlayerBitData.txt", false); //false=上書き
        //#else
        //        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/BitData/PlayerBitData.txt", false); //false=上書き
        //#endif

        //        sw.WriteLine(idx[0].ToString());
        //        sw.WriteLine(idx[1].ToString());
        //        sw.WriteLine(idx[2].ToString());
        //        sw.Flush();
        //        sw.Close();

        BitChange.instance.BitNum(0, idx[0]);
        BitChange.instance.BitNum(1, idx[1]);
        BitChange.instance.BitNum(2, idx[2]);
    }
}
