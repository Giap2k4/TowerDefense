using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListReward1
{
    public List<int> list;
}

[CreateAssetMenu(menuName = "SO/Reward", fileName = "Reward_")]
public class RewardSO : ScriptableObject
{
    public List<ListReward1> listReward;
}
