using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleHealthBar : MonoSingleton<CastleHealthBar>
{
    //can barý her kuleye saldýrý olduðunda güncellenir
    [SerializeField] private Image bar;
    public Image parentBar;


    public void CastleHealthUpdate()
    {
        bar.fillAmount = (float)CastleStat.Instance.health / (float)CastleStat.Instance.maxHealth;

        if (CastleStat.Instance.health <= 0)
        {
            AdManager.current.bannerView.Show();
            GameManager.Instance.inPlacement = false;
            GameManager.Instance.inMerge = false;
            GameManager.Instance.inFight = false;
            //genel game finish de kontrol et
            GameManager.Instance.inFinish = false;
            Buttons.Instance.finishGame.SetActive(true);
            GameManager.Instance.level++;
            GameManager.Instance.SetLevel();
            parentBar.gameObject.SetActive(false);
            Buttons.Instance.levelText.text = GameManager.Instance.level.ToString();
            //GetComponent<BoxCollider>().enabled = false;
        }

        if (GameManager.Instance.level % 10 == 0)
        {
            for (int i = 0; i < PlaneManager.Instance.planeObject.Count; i++)
            {
                PlaneManager.Instance.planeObject[i].SetActive(false);
            }
            PlaneManager.Instance.planeObject[GameManager.Instance.level / 10].SetActive(true);
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
