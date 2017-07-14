using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasma : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.01f;

    private bool HitFlag = false;
    private float HitColRot;
    private float Attack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HitFlag == false)
        {
            float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
            gameObject.transform.position += new Vector3(Mathf.Sin(angle) * speed, 0.0f, Mathf.Cos(angle) * speed);
        }
        else
        {
            //float angle = (gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
            //gameObject.transform.position += new Vector3(Mathf.Sin(angle) * speed, 0.0f, Mathf.Cos(angle) * speed);
            if (AttackerList.Instance.GetPlayerAttack(transform.tag, ref Attack))
            {
                if (transform.parent.GetComponent<EnemyBossLife>().GetLife() > 0)
                {
                    AudioManager.Instance.PlaySE("EnemyDestroy_1");
                    transform.parent.GetComponent<EnemyBossLife>().SubLife(Attack);
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
    }

    void OnTriggerStay(Collider col)
    {
        if( col.tag == "BossLife" )
        {
            HitFlag = true;
            Vector3 bouns;
            bouns = col.bounds.size;
            float angle = ( gameObject.transform.eulerAngles.y / 180.0f) * Mathf.PI;
            transform.position = col.gameObject.transform.position - new Vector3(Mathf.Sin(angle) * bouns.x, 0.0f, Mathf.Cos(angle) * bouns.z);
            transform.parent = col.transform;
        }
    }
}
