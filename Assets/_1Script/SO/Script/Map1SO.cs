using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListMovenment
{
    public List<Vector3> list;
}


[CreateAssetMenu(menuName = "SO/Map1")]
public class Map1SO : ScriptableObject
{
    public List<ListMovenment> listPos;
}
