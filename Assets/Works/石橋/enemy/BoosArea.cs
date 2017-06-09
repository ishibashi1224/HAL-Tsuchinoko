using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosArea : MonoBehaviour
{
    [SerializeField]
    private float Width = 0.0f;
    [SerializeField]
    private float Depth = 0.0f;
    [SerializeField]
    private float Height = 0.0f;

    public bool Detection(Vector3 pos)
    {
        if(transform.position.x - (Width * 0.5f) <= pos.x && transform.position.x + (Width * 0.5f) >= pos.x)
        {
            if (transform.position.z - (Depth * 0.5f) <= pos.z && transform.position.z + (Depth * 0.5f) >= pos.z)
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.92f, 0.016f, 0.4f);
        Gizmos.DrawCube(transform.position, new Vector3(Width, Height, Depth));
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, Depth));
    }
}
