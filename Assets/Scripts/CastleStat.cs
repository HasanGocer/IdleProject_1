using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStat : MonoSingleton<CastleStat>
{
    //kalenin can de�erini belirliyor ve i�indeki fonksiyon oyun sonunda yeni de�releri belirliyor
    public float archerArrowCountDown;
    public int maxHealth, health, newHealth;
    public int rivalWarriorCount;

    private void Start()
    {
        health = maxHealth;
    }
    public void SetCastelStat()
    {
        archerArrowCountDown = CastleStatManager.Instance.archerArrowCountdownFactor * GameManager.Instance.level;
        health = maxHealth;
        rivalWarriorCount = CastleStatManager.Instance.rivalWarriorCountFactor * GameManager.Instance.level;
    }
}
