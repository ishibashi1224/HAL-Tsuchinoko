using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitManager : MonoBehaviour
{
    private static int workNumber;
    private static GameObject workgameObject;
    private static bool CreateFlag = false ;
    private static GameObject[] oldbit = null;

    private static int bitlen; 
    [SerializeField]
    private GameObject[] bit = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        oldbit = bit;
        bitlen = bit.Length;
        /*if (CreateFlag)
        {
            bit[workNumber] = workgameObject;
            CreateFlag = false;
        }*/
    }
    
    public static int GetLength()
    {
        return bitlen;
    }

    public static GameObject GetBit (int idx)
    {
        return oldbit[idx];
    }

    public static void SetBit (int idx , GameObject gameobject)
    {
        //bit[idx] = gameobject;
        workNumber = idx;
        workgameObject = gameobject;
        CreateFlag = true;
    }
}
