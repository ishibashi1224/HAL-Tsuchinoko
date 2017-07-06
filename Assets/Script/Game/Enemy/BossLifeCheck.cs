using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject particle = null;
    private GameObject[] Object;
    private GameObject  _Object;
    // Use this for initialization
    void Start()
    {
        Object = GameObject.FindGameObjectsWithTag("BossLife");
        _Object = GameObject.FindGameObjectWithTag("BossHead");
    }

    // Update is called once per frame
    void Update()
    {
        for(int count = 0;  count < Object.Length; count++)
        {
            if(Object[count].GetComponentInChildren<EnemyBossLife>().GetUse() == true)
            {
                return;
            }
        }

        Instantiate(particle, _Object.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
