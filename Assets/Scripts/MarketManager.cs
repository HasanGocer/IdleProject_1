using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoSingleton<MarketManager>
{
    public int warriorSoeedPrice, WarriorCountPrice;
    public float warriorSoeedPriceFactor, WarriorCountPriceFactor;
    public float speedCurrent, speedNew;
    public float CountCurrent, CountNew;
    public Text WarriorSpeedText, WarriorCountText;

    public void SetMarket()
    {
        WarriorCountPrice = (int)((CountCurrent / CountNew) * WarriorCountPriceFactor);
        warriorSoeedPrice = (int)((speedCurrent / speedNew) * warriorSoeedPriceFactor);
        WarriorCountText.text = WarriorCountPrice.ToString();
        WarriorSpeedText.text = warriorSoeedPrice.ToString();
    }

    // deðer algoritmasý 
    //fiyat ve factörünü entegre
}
