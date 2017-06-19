using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBehavior : MonoBehaviour {

    protected EnemyBehavior enemyBehavior = null;
    protected DecisionBehavior decisionBehavior = null;

    public ChangeBehavior()
    {
        enemyBehavior = null;
    }

    public EnemyBehavior GetEnemyBehavior
    {
        get { return enemyBehavior; }
    }

    public void ChangeEnemyBehavior(EnemyBehavior behavior)
    {
        if (enemyBehavior != null)
        {
            enemyBehavior.Uninit();
        }
        enemyBehavior = behavior;
        enemyBehavior.Init();
    }

    public void Update()
    {
        if (enemyBehavior != null)
        {
            if(!enemyBehavior.Execute())
            {
                EnemyBehavior _enemyBehavior = decisionBehavior.Decision(enemyBehavior);
                if (_enemyBehavior != null)
                {
                    ChangeEnemyBehavior(_enemyBehavior);
                }
            }
        }
    }
}
