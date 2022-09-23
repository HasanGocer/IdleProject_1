using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelStat : MonoSingleton<CastelStat>
{
    public float archerArrowCountDown, archerArrowCountdownFactor;
    public int maxHealth, health, healthFactor;
    public int rivalWarriorCount, rivalWarriorCountFactor;

    public void SetCastelStat()
    {
        archerArrowCountDown = archerArrowCountdownFactor * GameManager.Instance.level;
        health = maxHealth;
        health = healthFactor * GameManager.Instance.level;
        rivalWarriorCount = rivalWarriorCountFactor * GameManager.Instance.level;
    }
}
