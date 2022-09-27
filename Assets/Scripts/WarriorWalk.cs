using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarriorWalk : MonoBehaviour
{
    //karakterin içinde olduðundan get companent ile çekilip bu fonksiyon çaðýrýldýðý an harekete geçer

    public void Walk()
    {
        transform.DOMove(WarriorStatManager.Instance.CastlePos.transform.position, (WarriorStatManager.Instance.WalkCountdownWay * Vector3.Distance(this.transform.position, WarriorStatManager.Instance.CastlePos.transform.position))).SetEase(Ease.InSine);
        //animasyon
    }
}
