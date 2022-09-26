using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoSingleton<CastleHealthBar>
{
    //can bar� her kuleye sald�r� oldu�unda g�ncellenir
    [SerializeField] private Image bar;

    public void CastleHealthUpdate()
    {
        bar.fillAmount = (float)CastelStat.Instance.health / (float)CastelStat.Instance.maxHealth;
    }
}
