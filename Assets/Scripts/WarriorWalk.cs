using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarriorWalk : MonoBehaviour
{
    //karakterin i�inde oldu�undan get companent ile �ekilip bu fonksiyon �a��r�ld��� an harekete ge�er

    public void Walk()
    {
        transform.DOMove(WarriorStatManager.Instance.CastlePos.transform.position, (WarriorStatManager.Instance.WalkCountdownWay * Vector3.Distance(this.transform.position, WarriorStatManager.Instance.CastlePos.transform.position))).SetEase(Ease.InSine);
        //animasyon
    }
}
