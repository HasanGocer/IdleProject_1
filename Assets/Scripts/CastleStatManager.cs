using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleStatManager : MonoSingleton<CastleStatManager>
{
    //kalenin statlarını evel yükseldikçe değiştirecek sabitlerin tutulduğu yerdir
    public float archerArrowCountdownFactor;
    public int healthFactor;
    public int rivalWarriorCountFactor;

}
