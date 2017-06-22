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
    public void Awake()
    {
        List<GameObject> Object = new List<GameObject>();
        Object.Add(Instantiate(Root, transform.position, transform.rotation));
        Object.Add(Instantiate(Area, transform.position, transform.rotation));
        Object.Add(Instantiate(Movement, transform.position, transform.rotation));
        Object.Add(Instantiate(Boss, transform.position, transform.rotation));
    }

    //public void Destruction()
    //{
    //    foreach(var list in Object)
    //    {
    //        Destroy(list);
    //    }
    //    Object.Clear();
    //}
}