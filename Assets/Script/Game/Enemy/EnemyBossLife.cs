using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossLife : MonoBehaviour
{

    [SerializeField]
    private float Life = 0.0f;
    [SerializeField]
    private GameObject particle = null;
    private float _Life = 0.0f;
    private Material material = null;
    private bool use = true;
    private float Attack;

    // Use this for initialization
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().materials[1];
        _Life = Life;
        use = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        material.SetFloat("_Range", Life / _Life);
        if (Life <= 0)
        {
            use = false;
        }
    }

    public void SubLife(float Power)
    {
        Life -= Power;
        if (Life <= 0)
        {
            GameObject obj = Instantiate(particle, transform.position, Quaternion.identity);
            obj.transform.parent = gameObject.transform;
            obj.transform.localScale = new Vector3(1, 1, 1);
            Destroy(gameObject.GetComponent<SphereCollider>());
            Life = 0;
        }
    }

    public float GetLife()
    {
        return Life;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (AttackerList.Instance.GetPlayerAttack(collider.tag, ref Attack))
        {
            AudioManager.Instance.PlaySE("敵撃破1");
            SubLife(Attack);
            if (collider.tag != "Beam")
            {
                collider.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (AttackerList.Instance.GetPlayerAttack(collider.tag, ref Attack))
        {
            if (collider.tag == "Beam")
            {
                AudioManager.Instance.PlaySE("敵撃破1");
                SubLife(Attack);
            }
        }
    }

    public bool GetUse()
    {
        return use;
    }
}
