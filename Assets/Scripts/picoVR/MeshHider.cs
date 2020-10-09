using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHider : MonoBehaviour
{
    private MeshRenderer[] _meshRenderers;
    
    void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void HideChildMeshRenderers()
    {
        foreach (MeshRenderer mr in _meshRenderers)
        {
            mr.enabled = false;
        }
    }

    public void ShowChildMeshRenderers()
    {
        foreach (MeshRenderer mr in _meshRenderers)
        {
            mr.enabled = true;
        }
    }
}
