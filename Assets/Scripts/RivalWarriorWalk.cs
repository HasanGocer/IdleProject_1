using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RivalWarriorWalk : MonoBehaviour
{
    [SerializeField] private GameObject focusWarrior;
    [SerializeField] private int OPRivalWarriorCount;
    [SerializeField] private float rivalWalkTime;

    private GameObject rivalWariror;
    private float minDistance = 10000f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            WalkSet();
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
            if (minDistance > Vector3.Distance(Warrior›nstantiate.Instance.WarriorObject[i].transform.position, WarriorStatManager.Instance.CastlePos.transform.position))
            {
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
