using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private float Life = 0.0f;
    [SerializeField]
    private GameObject particle = null;
    private float _Life = 0.0f;
    private Material material = null;
    private float Attack;

    private EnemySpawnManager Instance;

    // Use this for initialization
    void Start()
    {
        Instance = EnemySpawnManager.Instance;
        material = gameObject.GetComponent<Renderer>().materials[1];
        _Life = Life;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        material.SetFloat("_Range", Life / _Life);
        if (Life <= 0)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Life = _Life;
            Instance.Return(gameObject);
        }
    }

    public void SubLife(float Power)
    {
        Life -= Power;
        if (Life <= 0) Life = 0;
    }

    public float GetLife()
    {
        return Life;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (AttackerList.Instance.GetPlayerAttack(collider.tag, ref Attack))
        {
            AudioManager.Instance.PlaySE("EnemyDestroy_1");
            SubLife(Attack);
            if( collider.tag != "Beam" )
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
                AudioManager.Instance.PlaySE("EnemyDestroy_1");
                SubLife(Attack);
            }
        }
    }
}
