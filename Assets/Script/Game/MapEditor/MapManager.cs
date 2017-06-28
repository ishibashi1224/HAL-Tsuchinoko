using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonMonoBehaviourFast<MapManager>
{
    [SerializeField]
    private GameObject Map = null;

    //List<GameObject> Map = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        Instantiate(Map);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetMap(GameObject map)
    {
        Map = map;
    }
}
