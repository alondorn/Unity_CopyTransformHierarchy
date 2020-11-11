using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CopyMultipleTransforms))]
public class CopyMultipleTransformsEditor : Editor
{
    public static Transform[] copiedTransforms;
    public static Transform copiedTransform;
    public override void OnInspectorGUI()
    {
        CopyMultipleTransforms myTarget = (CopyMultipleTransforms)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Copy Transforms Values"))
        {
            copiedTransform = myTarget.GetTransform();
        }

        if (GUILayout.Button("Paste Transforms Values"))
        {
            if(copiedTransform == null)
            {
                Debug.Log("Please copy transform first.");
                return;
            }
            myTarget.SetTransforms2(copiedTransform);
        }
    }

}