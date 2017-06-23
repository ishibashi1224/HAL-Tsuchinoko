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

    // Use this for initialization
    void Start()
    {
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "bullet")
        {
            SubLife(10.0f);
            //Destroy(collider.gameObject);
            collider.gameObject.SetActive(false);
        }
    }
}
