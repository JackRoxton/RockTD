using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Waves", order = 1)]
public class Wave : ScriptableObject
{
    public int PickCount;
    public int HelmCount;
    public int DynaCount;
    public int ShovCount;
    public int CrowbCount;
    public int MiniBossCount;
    public int BossCount;
}
