using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private GameObject[] move = null;
    private int num;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num = 0;
        for (int count = 0; count < move.Length; count++)
        {
            if(move[count].activeSelf == true)
            {
                num++;
            }
        }

        if (num <= 0)
        {
            move[Random.Range(0, move.Length)].SetActive(true);
        }
    }
}
