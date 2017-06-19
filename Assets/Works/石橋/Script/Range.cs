using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField]
    private float range = 0.0f;
    private Material material = null;
    
    void Start()
    {
        material = gameObject.GetComponent<Renderer>().materials[1];
    }

    void Update()
    {
        material.SetFloat("_Range", range);
    }
}
