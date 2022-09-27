using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoSingleton<CastleHealthBar>
{
    //can barý her kuleye saldýrý olduðunda güncellenir
    [SerializeField] private Image bar;

    public void CastleHealthUpdate()
    {
        bar.fillAmount = (float)CastleStat.Instance.health / (float)CastleStat.Instance.maxHealth;

        if (CastleStat.Instance.health == 0)
        {
            GameManager.Instance.inPlacement = false;
            GameManager.Instance.inMerge = false;
            GameManager.Instance.inFight = false;
            //genel game finish de kontrol et
            GameManager.Instance.inFinish = false;
            Buttons.Instance.finishGame.SetActive(true);
        }
    }
}
