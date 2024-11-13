using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy", fileName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public int hp;
    public float speed;
    public int goldDead;
}
