using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attacker
{
    public string Tag;
    public float Attack;
}

public class AttackerList : SingletonMonoBehaviourFast<AttackerList>
{
    [SerializeField]
    private List<Attacker> player;
    [SerializeField]
    private List<Attacker> enemy;

    public bool GetPlayerAttack(string Tag, ref float Attack)
    {
        foreach(var list in player)
        {
            if(list.Tag == Tag)
            {
                Attack = list.Attack;
                return true;
            }
        }

        return false;
    }

    public bool GetEnemyAttack(string Tag, ref float Attack)
    {
        foreach (var list in enemy)
        {
            if (list.Tag == Tag)
            {
                Attack = list.Attack;
                return true;
            }
        }

        return false;
    }
}
