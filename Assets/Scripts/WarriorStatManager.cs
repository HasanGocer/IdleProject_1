using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStatManager : MonoSingleton<WarriorStatManager>
{
    //warriorların ana statlarının tutulduğu yerdir ve çekilmesi gereken ana değerlerin çekildiği yeridir

    public int warriorCount, currentWarriorCount,newWarriorCount;
    public GameObject CastlePos;
    public float WalkCountdownWay,newWalkSpeed;
}
