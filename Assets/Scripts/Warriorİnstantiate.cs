using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorİnstantiate : MonoSingleton<Warriorİnstantiate>
{
    [SerializeField] private GameObject _rivalCastel;
    [SerializeField] private int _OPWarriorCount;
    [SerializeField] private int _setWarriorLevel;

    //warriorun doğacağı yeri vermemiz yetiyor oraya warrior spawnlıyor;
    public void WarriorSpawn(GameObject pos)
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPWarriorCount);

        obj.GetComponent<WarriorStat>().level = _setWarriorLevel;
        obj.GetComponent<WarriorStat>().SetStat();

        obj.transform.position = pos.transform.position;
        obj.transform.LookAt(_rivalCastel.transform);
    }

}
