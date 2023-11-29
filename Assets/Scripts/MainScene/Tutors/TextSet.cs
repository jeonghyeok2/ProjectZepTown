using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSet : MonoBehaviour
{
    public int sortingOrder;

    private void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        mesh.sortingOrder = sortingOrder;
    }
}
