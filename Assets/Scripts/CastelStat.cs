using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelStat : MonoSingleton<CastelStat>
{
    public float archerArrowCountDown;
    public int maxHealth, health;
    public int rivalWarriorCount;

    public void SetCastelStat()
    {
        archerArrowCountDown = CastleStatManager.Instance.archerArrowCountdownFactor * GameManager.Instance.level;
        health = maxHealth;
        health = CastleStatManager.Instance.healthFactor * GameManager.Instance.level;
        rivalWarriorCount = CastleStatManager.Instance.rivalWarriorCountFactor * GameManager.Instance.level;
    }
}
