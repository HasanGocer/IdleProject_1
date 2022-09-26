using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun tüm prefeblerinin ve oyunun hangi safhasýnda olduðu deðeri burada dönülür

    //Bools
    public bool startGame;
    public bool inPlacement;
    public bool inMerge;
    public bool inFight;
    public bool inMarket;
    public bool inFail;
    public bool inFinish;
    public bool inGameFinish;


    public int level;
    public int money;

    private void Start()
    {
        inPlacement = true;
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
        }

        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
        }

        if (PlayerPrefs.HasKey("archerArrowCountdown"))
        {
            CastelStat.Instance.archerArrowCountDown = PlayerPrefs.GetFloat("archerArrowCountDown");
        }
        else
        {
            PlayerPrefs.SetFloat("archerArrowCountDown", CastelStat.Instance.archerArrowCountDown);
        }

        if (PlayerPrefs.HasKey("health"))
        {
            CastelStat.Instance.health = PlayerPrefs.GetInt("health");
        }
        else
        {
            PlayerPrefs.SetInt("health", CastelStat.Instance.health);
        }

        if (PlayerPrefs.HasKey("rivalWarriorCount"))
        {
            CastelStat.Instance.rivalWarriorCount = PlayerPrefs.GetInt("rivalWarriorCount");
        }
        else
        {
            PlayerPrefs.SetInt("rivalWarriorCount", CastelStat.Instance.rivalWarriorCount);
        }

        if (PlayerPrefs.HasKey("warriorCount"))
        {
            WarriorStatManager.Instance.warriorCount = PlayerPrefs.GetInt("warriorCount");
        }
        else
        {
            PlayerPrefs.SetInt("warriorCount", WarriorStatManager.Instance.warriorCount);
        }
    }

    public void SetLevel()
    {
        CastelStat.Instance.SetCastelStat();
        PlayerPrefs.SetInt("level", level);
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("money", money);
    }

    public void SetArcherArrowCountdown()
    {
        PlayerPrefs.SetFloat("archerArrowCountdown", CastelStat.Instance.archerArrowCountDown);
    }

    public void SetHealth()
    {
        PlayerPrefs.SetInt("health", CastelStat.Instance.health);
    }

    public void SetRivalWarriorCount()
    {
        PlayerPrefs.SetInt("rivalWarriorCount", CastelStat.Instance.rivalWarriorCount);
    }

    public void SetWarriorCount()
    {
        PlayerPrefs.SetInt("warriorCount", WarriorStatManager.Instance.warriorCount);
    }
}
