using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonMonoBehaviourFast<MapManager>
{
    [SerializeField]
    List<GameObject> Map = new List<GameObject>();

    int nCnt = -1;

    // Use this for initialization
    void Start()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
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
        else if (nCnt > Map.Count)
        {
            nCnt = Map.Count;
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
