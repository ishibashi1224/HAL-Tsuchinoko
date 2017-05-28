using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private float Life = 0.0f;
    [SerializeField]
    private GameObject particle = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Life <= 0)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            SubLife(10.0f);
        }
        Destroy(collision.gameObject);
    }
}
