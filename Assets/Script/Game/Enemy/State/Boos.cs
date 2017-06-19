using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos : ChangeBehavior
{
    [SerializeField]
    private DecisionBehavior Behavior = null;

    void Start()
    {
        decisionBehavior = Behavior;
        enemyBehavior = decisionBehavior.Decision(null);
        enemyBehavior.Init();
    }
}
