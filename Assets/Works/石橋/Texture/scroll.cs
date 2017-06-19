using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 Speed = new Vector2(0, 0);
    [SerializeField]
    private Material ScrollTex = null;

    private Vector2 offset;

    void Start()
    {
        offset = ScrollTex.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * Speed.x, 1);
        float y = Mathf.Repeat(Time.time * Speed.y, 1);

       // offset = new Vector2(x, y);

        ScrollTex.SetTextureOffset("_MainTex", offset + new Vector2(x, y));
    }
}

//public class scroll : MonoBehaviour
//{
//    [SerializeField]
//    private Vector2 Speed = new Vector2(0, 0);
//    [SerializeField]
//    private Material ScrollTex = null;

//    private Vector2 offset;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        float x = Mathf.Repeat(Time.time * Speed.x, 1);
//        float y = Mathf.Repeat(Time.time * Speed.y, 1);

//        offset = new Vector2(x, y);

//        ScrollTex.SetTextureOffset("_MainTex", offset);
//    }
//}
