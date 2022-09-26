using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelStat : MonoSingleton<CastelStat>
{
    //kalenin can de�erini belirliyor ve i�indeki fonksiyon oyun sonunda yeni de�releri belirliyor
    public float archerArrowCountDown;
    public int maxHealth, health;
    public int rivalWarriorCount;

    private void Start()
    {
        health = maxHealth;
    }
    public void SetCastelStat()
    {
        archerArrowCountDown = CastleStatManager.Instance.archerArrowCountdownFactor * GameManager.Instance.level;
        health = maxHealth;
        health = CastleStatManager.Instance.healthFactor * GameManager.Instance.level;
        rivalWarriorCount = CastleStatManager.Instance.rivalWarriorCountFactor * GameManager.Instance.level;
    }
}
