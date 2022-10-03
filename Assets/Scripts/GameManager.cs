using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun t�m prefeblerinin ve oyunun hangi safhas�nda oldu�u de�eri burada d�n�l�r

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
    public int money, addedMoney;
    public int vibration;
    public int sound;

    private void Start()
    {
        startGame = true;
        GameObject.FindObjectOfType<AdManager>().InitializeAds();
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

        if (PlayerPrefs.HasKey("vibration"))
        {
            vibration = PlayerPrefs.GetInt("vibration");
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
        }

        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
        }

        if (PlayerPrefs.HasKey("archerArrowCountdown"))
        {
            CastleStat.Instance.archerArrowCountDown = PlayerPrefs.GetFloat("archerArrowCountDown");
        }
        else
        {
            PlayerPrefs.SetFloat("archerArrowCountDown", CastleStat.Instance.archerArrowCountDown);
        }

        if (PlayerPrefs.HasKey("health"))
        {
            CastleStat.Instance.maxHealth = PlayerPrefs.GetInt("health");
        }
        else
        {
            PlayerPrefs.SetInt("health", CastleStat.Instance.maxHealth);
        }

        if (PlayerPrefs.HasKey("rivalWarriorCount"))
        {
            CastleStat.Instance.rivalWarriorCount = PlayerPrefs.GetInt("rivalWarriorCount");
        }
        else
        {
            PlayerPrefs.SetInt("rivalWarriorCount", CastleStat.Instance.rivalWarriorCount);
        }

        if (PlayerPrefs.HasKey("warriorCount"))
        {
            WarriorStatManager.Instance.warriorCount = PlayerPrefs.GetInt("warriorCount");
        }
        else
        {
            PlayerPrefs.SetInt("warriorCount", WarriorStatManager.Instance.warriorCount);
        }

        if (PlayerPrefs.HasKey("WalkCountdownWay"))
        {
            WarriorStatManager.Instance.WalkCountdownWay = PlayerPrefs.GetFloat("WalkCountdownWay");
        }
        else
        {
            PlayerPrefs.SetFloat("WalkCountdownWay", WarriorStatManager.Instance.WalkCountdownWay);
        }

        if (PlayerPrefs.HasKey("countMoney"))
        {
            MarketManager.Instance.WarriorCountPrice = PlayerPrefs.GetInt("countMoney");
        }
        else
        {
            PlayerPrefs.SetFloat("countMoney", MarketManager.Instance.WarriorCountPrice);
        }

        if (PlayerPrefs.HasKey("speedMoney"))
        {
            MarketManager.Instance.warriorSoeedPrice = PlayerPrefs.GetInt("speedMoney");
        }
        else
        {
            PlayerPrefs.SetFloat("speedMoney", MarketManager.Instance.warriorSoeedPrice);
        }
    }

    public void SetLevel()
    {
        CastleStat.Instance.SetCastelStat();
        PlayerPrefs.SetInt("level", level);
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("money", money);
    }

    public void SetSound()
    {
        PlayerPrefs.SetInt("sound", sound);
    }

    public void SetVibration()
    {
        PlayerPrefs.SetInt("vibration", vibration);
    }

    public void SetArcherArrowCountdown()
    {
        PlayerPrefs.SetFloat("archerArrowCountdown", CastleStat.Instance.archerArrowCountDown);
    }

    public void SetHealth()
    {
        PlayerPrefs.SetInt("health", CastleStat.Instance.maxHealth);
    }

    public void SetRivalWarriorCount()
    {
        PlayerPrefs.SetInt("rivalWarriorCount", CastleStat.Instance.rivalWarriorCount);
    }

    public void SetWarriorCount()
    {
        PlayerPrefs.SetInt("warriorCount", WarriorStatManager.Instance.warriorCount);
    }
    public void SetWarriorWalkSpeed()
    {
        PlayerPrefs.SetFloat("WalkCountdownWay", WarriorStatManager.Instance.WalkCountdownWay);
    }

    public void SetWarriorCountMoney()
    {
        PlayerPrefs.SetFloat("speedMoney", MarketManager.Instance.WarriorCountPrice);
    }

    public void SetWarriorSpeedMoney()
    {
        PlayerPrefs.SetFloat("speedMoney", MarketManager.Instance.warriorSoeedPrice);
    }
}
