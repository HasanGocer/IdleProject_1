using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalWarriorWalk : MonoSingleton<RivalWarriorWalk>
{
    //Bu kodda rical Warrior spawn ediliyor saldýracaðý warrior seçiliyor ve harekete geçiriliyor
    //HATA= bir warriora birden fazla rival Warrior gidiyor

    [SerializeField] private int OPRivalWarriorCount;
    [SerializeField] private float rivalWalkTime;
    [SerializeField] private float rivalCountDawn;
    [SerializeField] private bool focusOnWarrior;

    private GameObject focusWarrior;
    private GameObject rivalWariror;
    private float minDistance = 10000f;

    public IEnumerator RivalWarriorWalkEnumerator()
    {
        while (true)
        {
            for (int i = 0; i < WarriorÝnstantiate.Instance.WarriorObject.Count; i++)
            {
                if (!WarriorÝnstantiate.Instance.WarriorBool[i])
                {
                    focusOnWarrior = true;
                }
            }
            if (GameManager.Instance.inFight && WarriorÝnstantiate.Instance.WarriorObject.Count > 0 && focusOnWarrior)
            {
                SpawnRivalWarrior();
                SetRival();
                WalkWarrior();
                focusOnWarrior = false;
            }
            yield return new WaitForSeconds(rivalCountDawn);
        }
    }

    private void SpawnRivalWarrior()
    {
        rivalWariror = ObjectPool.Instance.GetPooledObject(OPRivalWarriorCount);
        rivalWariror.transform.position = WarriorStatManager.Instance.CastlePos.transform.position;
    }

    private void SetRival()
    {
        for (int i = 0; i < WarriorÝnstantiate.Instance.WarriorObject.Count; i++)
        {
            if (minDistance > Vector3.Distance(WarriorÝnstantiate.Instance.WarriorObject[i].transform.position, WarriorStatManager.Instance.CastlePos.transform.position) && !WarriorÝnstantiate.Instance.WarriorBool[i])
            {
                WarriorÝnstantiate.Instance.WarriorBool[i] = true;
                minDistance = Vector3.Distance(WarriorÝnstantiate.Instance.WarriorObject[i].transform.position, WarriorStatManager.Instance.CastlePos.transform.position);
                focusWarrior = WarriorÝnstantiate.Instance.WarriorObject[i];
            }
        }
        minDistance = 1000f;
    }

    private void WalkWarrior()
    {
        rivalWariror.transform.LookAt(focusWarrior.transform.position);
        rivalWariror.transform.DOMove(focusWarrior.transform.position, rivalWalkTime);
    }
}
