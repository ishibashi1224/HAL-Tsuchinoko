using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 ScrollMove;

    private Vector2 _Scroll;
    private Material _Material;

    // Use this for initialization
    void Start()
    {
        _Scroll = new Vector2(0.0f, 0.0f);
        _Material = GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        _Scroll += ScrollMove;
        _Scroll.x = Mathf.Repeat(_Scroll.x, 1.0f);
        _Scroll.y = Mathf.Repeat(_Scroll.y, 1.0f);
        _Material.SetTextureOffset("_MainTex", _Scroll);
    }
}
