using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public List<Transform> List = new List<Transform>();
    public bool LineShow = true;
    public Color LineColor = Color.yellow;
    private int num = 2; //最低数

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        if (LineShow)
        {
            Gizmos.color = LineColor;
            for (int count = 0; count < List.Count - 1; count++)
            {
                Gizmos.DrawLine(List[count].transform.position, List[count + 1].transform.position);
            }
            for (int count = 0; count < List.Count; count++)
            {
                Gizmos.DrawSphere(List[count].transform.position, 1.0f);
            }
        }
    }

    //頂点の追加
    public void InsertPoint(int ID)
    {
        if (Application.isPlaying) return;
        GameObject point = new GameObject();
        point.AddComponent<RootPoint>();
        point.transform.parent = gameObject.transform;
        List.Insert(ID, point.transform);
        Vector3 Pos;
        if (ID == 0)
            Pos = List[ID + 1].position;
        else if (ID == List.Count - 2)
            Pos = List[ID + 1].position;
        else
            Pos = (List[ID - 1].position + List[ID + 1].position) * 0.5f;
        point.transform.position = Pos;
        RenameList();
        ((RootPoint)point.GetComponent("RootPoint")).Init();
    }

    public int RemovePoint(int ID)
    {
        if (Application.isPlaying) return 0;
        if (List.Count <= num) return 0;
        DestroyImmediate(List[ID].gameObject);
        List.RemoveAt(ID);
        RenameList();
        return 1;
    }

    public void AddPoint()
    {
        if (List.Count == 0)
        {
            for (int count = 0; count < num; count++)
            {
                GameObject point = new GameObject();
                point.AddComponent<RootPoint>();
                point.transform.parent = gameObject.transform;
                List.Add(point.transform);
                point.transform.position = gameObject.transform.position;

                ((RootPoint)point.GetComponent("RootPoint")).Init();
            }
        }
        RenameList();
    }

    public void RenameList()
    {
        for (int count = 0; count < List.Count; count++)
        {
            List[count].gameObject.name = "Point" + (count + 1).ToString("0000");
            List[count].SetAsLastSibling();
        }
    }
}
