using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthBar : MonoSingleton<CastleHealthBar>
{
    //can bar� her kuleye sald�r� oldu�unda g�ncellenir
    [SerializeField] private Image bar;
    [SerializeField]
    public GameObject castleBarUI;

    public void CastleHealthUpdate()
    {
        bar.fillAmount = (float)CastleStat.Instance.health / (float)CastleStat.Instance.maxHealth;

        if (CastleStat.Instance.health <= 0)
        {
            GameManager.Instance.inPlacement = false;
            GameManager.Instance.inMerge = false;
            GameManager.Instance.inFight = false;
            //genel game finish de kontrol et
            GameManager.Instance.inFinish = false;
            Buttons.Instance.finishGame.SetActive(true);
            GameManager.Instance.level++;
            GameManager.Instance.SetLevel();
            CastleHealthBar.Instance.castleBarUI.SetActive(false);
            Buttons.Instance.levelText.text = GameManager.Instance.level.ToString();
            GetComponent<BoxCollider>().enabled = false;
        }
        /*if (CastelStat.Instance.health >= 0 && WarriorStatManager.Instance.currentWarriorCount >= WarriorStatManager.Instance.warriorCount )
        {
            GameManager.Instance.inPlacement = false;
            GameManager.Instance.inMerge = false;
            GameManager.Instance.inFight = false;
            GameManager.Instance.inFinish = false;
            Buttons.Instance.finishGame.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
        }*/
    }
}
