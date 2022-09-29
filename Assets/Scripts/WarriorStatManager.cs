using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStatManager : MonoSingleton<WarriorStatManager>
{
    //warriorlar�n ana statlar�n�n tutuldu�u yerdir ve �ekilmesi gereken ana de�erlerin �ekildi�i yeridir

    public int warriorCount, currentWarriorCount, newWarriorCount;
    public GameObject CastlePos;
    public float WalkCountdownWay, newWalkSpeed;
}
