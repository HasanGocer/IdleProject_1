using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalWarriorWalk : MonoSingleton<RivalWarriorWalk>
{
    //Bu kodda rical Warrior spawn ediliyor sald˝raca˝ warrior seÁiliyor ve harekete geÁiriliyor
    //HATA= bir warriora birden fazla rival Warrior gidiyor

    [SerializeField] private int OPRivalWarriorCount;
    [SerializeField] private float rivalWalkTime;
    [SerializeField] private float rivalCountDawn;

    private GameObject focusWarrior;
    private GameObject rivalWariror;
    private float minDistance = 10000f;

    public IEnumerator RivalWarriorWalkEnumerator()
    {
        while (true)
        {
            if (GameManager.Instance.inFight)
                WalkSet();
            yield return new WaitForSeconds(rivalCountDawn);
        }
    }

    public void WalkSet()
    {
        if (Warrior›nstantiate.Instance.WarriorObject.Count > 0)
        {
            SpawnRivalWarrior();
            SetRival();
            WalkWarrior();
        }
    }

    private void SpawnRivalWarrior()
    {
        rivalWariror = ObjectPool.Instance.GetPooledObject(OPRivalWarriorCount);
        rivalWariror.transform.position = WarriorStatManager.Instance.CastlePos.transform.position;
    }

    private void SetRival()
    {
        for (int i = 0; i < Warrior›nstantiate.Instance.WarriorObject.Count; i++)
        {
            if (minDistance > Vector3.Distance(Warrior›nstantiate.Instance.WarriorObject[i].transform.position, WarriorStatManager.Instance.CastlePos.transform.position) && !Warrior›nstantiate.Instance.WarriorBool[i])
            {
                Warrior›nstantiate.Instance.WarriorBool[i] = true;
                minDistance = Vector3.Distance(Warrior›nstantiate.Instance.WarriorObject[i].transform.position, WarriorStatManager.Instance.CastlePos.transform.position);
                focusWarrior = Warrior›nstantiate.Instance.WarriorObject[i];
            }
        }
    }

    private void WalkWarrior()
    {
        rivalWariror.transform.LookAt(focusWarrior.transform.position);
        rivalWariror.transform.DOMove(focusWarrior.transform.position, rivalWalkTime);
    }
}
