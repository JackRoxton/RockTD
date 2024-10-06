using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> list;

    public Transform NextPath(int a)
    {
        if (a >= list.Count) return null;
        return list[a];
    }
}
