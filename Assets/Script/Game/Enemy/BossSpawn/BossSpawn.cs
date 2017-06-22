using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Root = null;
    [SerializeField]
    private GameObject Area = null;
    [SerializeField]
    private GameObject Movement = null;
    [SerializeField]
    private GameObject Boss = null;

    private List<GameObject> Object = null;

    // Use this for initialization
    public void Create()
    {
        List<GameObject> Object = new List<GameObject>();
        Object.Add(Instantiate(Root));
        Object.Add(Instantiate(Area));
        Object.Add(Instantiate(Movement));
        Object.Add(Instantiate(Boss));
    }

    public void Destruction()
    {
        foreach(var list in Object)
        {
            Destroy(list);
        }
        Object.Clear();
    }
}