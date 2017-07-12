using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class _Beam : MonoBehaviour
{
    [SerializeField]
    private float Length;

    [SerializeField]
    private float StartPos = 0;

    private LineRenderer Line;

    // Use this for initialization
    void Start()
    {
        Line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = (transform.eulerAngles.y / 180.0f) * Mathf.PI;
        Vector3 pos = transform.position;
        pos += new Vector3(Mathf.Sin(angle) * StartPos, 0.0f, Mathf.Cos(angle) * StartPos);
        Line.SetPosition(0, pos);
        pos += new Vector3(Mathf.Sin(angle) * Length, 0.0f, Mathf.Cos(angle) * Length);
        Line.SetPosition(1, pos);
        AudioManager.Instance.PlaySE("shot_ver2");
    }
}
