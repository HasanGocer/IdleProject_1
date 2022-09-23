using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //Bools
    public bool startGame;
    public bool inGame;
    public bool inFight;
    public bool inMarket;
    public bool inFail;
    public bool inFinish;
    public bool inGameFinish;


    public int level;
    public int money;

    private void Start()
    {
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
    }

    public void SetLevel()
    {
        level++;
        CastelStat.Instance.SetCastelStat();
    }
}
