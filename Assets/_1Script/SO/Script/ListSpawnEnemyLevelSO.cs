using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListEnemy1
{
    public List<int> listEnemy;
}

[CreateAssetMenu(menuName = "SO/ListSpawnEnemyLevel")]
public class ListSpawnEnemyLevelSO : ScriptableObject
{
    public List<ListEnemy1> listSpawnEnemy;

    public List<int> List(int a)
    {
        return listSpawnEnemy[a].listEnemy;
    }
}
