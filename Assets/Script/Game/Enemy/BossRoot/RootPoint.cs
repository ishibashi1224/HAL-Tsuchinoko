using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RootPoint : MonoBehaviour {

    private Root root;
    private Transform tr;
    private Vector3 posOld;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        tr = transform;
        posOld = tr.position;
        if (tr.parent != null)
            root = (Root)tr.parent.gameObject.GetComponent("Root");
    }

    void Update()
    {
        if (Vector3.Distance(tr.position, posOld) > 0.01f)
        {
            posOld = tr.position;
        }
    }
}
