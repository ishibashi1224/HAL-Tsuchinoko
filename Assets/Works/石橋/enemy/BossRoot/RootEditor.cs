using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Root))]
public class RootEditor : Editor
{
    private static Root instance;
    private GUIContent content;
    private bool foldout = true;

    void Awake()
    {
        instance = (Root)target;
        EditorUtility.SetDirty(instance);
    }

    public override void OnInspectorGUI()
    {
        instance = (Root)target;
        GUI.changed = false;

        foldout = EditorGUILayout.Foldout(foldout, "RootList");
        if (foldout)
        {
            if (instance.List.Count == 0)
            {
                if (GUILayout.Button("Add Control Point"))
                    instance.AddPoint();
            }

            for (int count = 0; count < instance.List.Count; count++)
            {
                GUILayout.BeginHorizontal();

                GUILayout.Label("   Point " + (count + 1).ToString("0000"));

                instance.List[count] = (Transform)EditorGUILayout.ObjectField(instance.List[count], typeof(Transform), true);

                //リストの追加
                if (GUILayout.Button("+", GUILayout.MaxWidth(20)))
                    instance.InsertPoint(count);
                //リストの削減
                if (GUILayout.Button("-", GUILayout.MaxWidth(20)))
                    count -= instance.RemovePoint(count);

                GUILayout.EndHorizontal();
            }
        }

        content = new GUIContent("ShowLine");
        instance.LineShow = EditorGUILayout.Toggle(content, instance.LineShow);
        if (instance.LineShow)
        {
            content = new GUIContent("Color");
            instance.LineColor = EditorGUILayout.ColorField(content, instance.LineColor);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(instance);
        }
    }
}
