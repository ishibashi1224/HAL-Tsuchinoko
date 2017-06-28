using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : SingletonMonoBehaviourFast<EnemySpawnManager>
{
    [SerializeField]
    private int EnemyMax = 0;
    private List<GameObject> Enemy;
    private List<GameObject> EnemyPool;

    // Use this for initialization
    void Start()
    {
        Enemy = new List<GameObject>();
        EnemyPool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Return(GameObject _Enemy)
    {
        EnemyPool.Add(_Enemy);
        _Enemy.SetActive(false);
    }

    public bool Place(Vector3 Pos)
    {
        if(EnemyPool.Count > 0)
        {
                EnemyPool[EnemyPool.Count - 1].SetActive(true);
                EnemyPool[EnemyPool.Count - 1].transform.position = Pos;
                EnemyPool.RemoveAt(EnemyPool.Count - 1);

                return true;
        }
        return false;
    }

    public void Add(GameObject _Enemy)
    {
        Enemy.Add(_Enemy);
    }

    public bool Creat()
    {
        if(Enemy.Count >= EnemyMax)
        {
            return false;
        }
        return true;
    }
}
