using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoBehaviour
{
    //can barý her kuleye saldýrý olduðunda güncellenir
    [SerializeField] private Image bar;

    public void CastleHealthUpdate()
    {
        bar.fillAmount = CastelStat.Instance.health / CastelStat.Instance.maxHealth;
    }
}
