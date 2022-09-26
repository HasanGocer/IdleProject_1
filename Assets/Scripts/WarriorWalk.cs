using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarriorWalk : MonoBehaviour
{

    public void Walk()
    {
        transform.DOMove(WarriorStatManager.Instance.CastlePos.transform.position, WarriorStatManager.Instance.WalkCountdown).SetEase(Ease.InSine);
        //animasyon
    }
}
