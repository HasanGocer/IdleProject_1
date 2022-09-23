using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStat : MonoBehaviour
{
    [SerializeField] private int healthCount;
    [SerializeField] private float speed;
    public int level;

    public void SetStat()
    {
        for (int i = 1; i <= WarriorStatManager.Instance.level.Count; i++)
        {
            if (level == i)
            {
                speed = WarriorStatManager.Instance.speed[i];
                healthCount = WarriorStatManager.Instance.healthCount[i];
            }
        }
    }
}
