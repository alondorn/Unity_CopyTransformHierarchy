using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMultipleTransforms : MonoBehaviour {

    public Transform GetTransform()
    {
        Transform copiedTransform = transform;
        return copiedTransform;
    }

    public void SetTransforms2(Transform copiedTransform)
    {
        List<Transform> copiedTransforms = new List<Transform>();
        copiedTransforms.Add(copiedTransform);
        List<Transform> targetTransforms = new List<Transform>();
        targetTransforms.Add(transform);
        SetTransformsRecursive(copiedTransforms, targetTransforms);
    }

    void SetTransformsRecursive(List<Transform> copiedTransforms, List<Transform> targetTransforms)
    {
        Debug.Log("copiedTransforms: " + copiedTransforms.Count + ", targetTransforms: " + targetTransforms.Count);
        for (int i = 0; i < copiedTransforms.Count; i++)
        {
            for (int y = 0; y < targetTransforms.Count; y++)
            {
                if (copiedTransforms[i].name == targetTransforms[y].name)
                {
                    targetTransforms[y].localPosition = copiedTransforms[i].localPosition;
                    targetTransforms[y].localRotation = copiedTransforms[i].localRotation;
                    targetTransforms[y].localScale = copiedTransforms[i].localScale;
                    if (copiedTransforms[i].childCount > 0 && targetTransforms[y].childCount > 0)
                    {
                        List<Transform> copiedChildren = new List<Transform>();
                        for(int t = 0; t< copiedTransforms[i].childCount; t++)
                        {
                            copiedChildren.Add(copiedTransforms[i].GetChild(t));
                        }
                        List<Transform> targetChildren = new List<Transform>();
                        for (int t = 0; t < targetTransforms[y].childCount; t++)
                        {
                            targetChildren.Add(targetTransforms[y].GetChild(t));
                        }
                        SetTransformsRecursive(copiedChildren, targetChildren);
                    }
                }
            }
        }
    }



}
