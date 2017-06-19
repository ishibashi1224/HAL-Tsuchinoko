using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField]
    private GameObject Object = null;
    [SerializeField]
    private List<GameObject> Parts = null;
    [SerializeField]
    private float Speed = 0.0f;
    [SerializeField]
    private int Frame = 0;

    private List<Vector3> pos = new List<Vector3>();
    private List<Quaternion> rot = new List<Quaternion>();
    private int num;
    private bool use;

    void Start()
    {
        use = true;
        num = 0;
        pos.Add(Object.transform.position);
        rot.Add(Object.transform.rotation);
    }

    void Update()
    {
        if (use)
        {
            //if (pos[pos.Count - 1] != Object.transform.position)
            {
                pos.Add(Object.transform.position);
                rot.Add(Object.transform.rotation);
                num++;
                if (num > Frame * Parts.Count)
                {
                    use = false;
                }
            }
        }
        else
        {
            //if (pos[pos.Count - 1] != Object.transform.position)
            {
                pos.Add(Object.transform.position);
                rot.Add(Object.transform.rotation);

                for (int count = 0; count < Parts.Count; count++)
                {
                    //Parts[count].transform.position = pos[Frame * ((Parts.Count - 1) - count)];
                    Parts[count].transform.position = Vector3.Lerp(Parts[count].transform.position, pos[Frame * ((Parts.Count - 1) - count)], Speed);
                    //Parts[count].transform.rotation = rot[Frame * ((Parts.Count - 1) - count)];
                    Parts[count].transform.rotation = Quaternion.Lerp(Parts[count].transform.rotation, rot[Frame * ((Parts.Count - 1) - count)], Speed);
                }

                pos.RemoveAt(0);
                rot.RemoveAt(0);
            }
        }

        //Parts[0].transform.rotation = Quaternion.Lerp(Parts[0].transform.rotation, Object.transform.rotation, Speed);
        //for (int count = 1; count < Parts.Count; count++)
        //{
        //    Parts[count].transform.rotation = Quaternion.Lerp(Parts[count].transform.rotation, Parts[count - 1].transform.rotation, Speed);
        //}
    }

    //[SerializeField]
    //private GameObject Object = null;
    //[SerializeField]
    //private List<GameObject> Parts = null;
    //[SerializeField]
    //private float Speed = 0.0f;

    //void Start()
    //{

    //}

    //void Update()
    //{
    //    Parts[0].transform.position = Vector3.Lerp(Parts[0].transform.position, Object.transform.position, Speed);
    //    Parts[0].transform.rotation = Quaternion.Lerp(Parts[0].transform.rotation, Object.transform.rotation, Speed);
    //    for (int count = 1; count < Parts.Count; count++)
    //    {
    //        Parts[count].transform.position = Vector3.Lerp(Parts[count].transform.position, Parts[count - 1].transform.position, Speed);
    //        Parts[count].transform.rotation = Quaternion.Lerp(Parts[count].transform.rotation, Parts[count - 1].transform.rotation, Speed);
    //    }
    //}
}
