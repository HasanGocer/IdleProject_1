using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStatManager : MonoSingleton<WarriorStatManager>
{
    //warriorlarýn ana statlarýnýn tutulduðu yerdir ve çekilmesi gereken ana deðerlerin çekildiði yeridir

    public int warriorCount, currentWarriorCount, newWarriorCount;
    public GameObject CastlePos;
    public float WalkCountdownWay, newWalkSpeed;
}
