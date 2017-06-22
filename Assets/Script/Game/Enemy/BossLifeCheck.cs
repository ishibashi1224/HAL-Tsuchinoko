using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject particle = null;
    private GameObject[] Object;
    // Use this for initialization
    void Start()
    {
        Object = GameObject.FindGameObjectsWithTag("BossLife");
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

        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
