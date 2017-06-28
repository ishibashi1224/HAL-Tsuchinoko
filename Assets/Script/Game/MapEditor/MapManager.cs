using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonMonoBehaviourFast<MapManager>
{
    [SerializeField]
    //private GameObject Map = null;
    List<GameObject> Map = new List<GameObject>();

    int nCnt = -1;

    // Use this for initialization
    void Start()
    {
        CountSetMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountSetMap()
    {
        if(nCnt < Map.Count)
        {
            nCnt++;
            Instantiate(Map[nCnt]);
        }

        if (nCnt > Map.Count)
        {
            nCnt = -1;
        }
    }

    public void GetMap(List<GameObject> map)
    {
        Map = map;
    }

    public void DelMap()
    {
        Map = null;
    }
}
