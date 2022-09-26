using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorİnstantiate : MonoSingleton<Warriorİnstantiate>
{
    //warrior spawn eden fonksiyon
    [SerializeField] private GameObject _rivalCastel;
    [SerializeField] private int _OPWarriorCount;
    public List<GameObject> WarriorObject = new List<GameObject>();
    public List<bool> WarriorBool = new List<bool>();

    //warriorun doğacağı yeri vermemiz yetiyor oraya warrior spawnlıyor;
    public void WarriorSpawn(GameObject pos)
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPWarriorCount);

        obj.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y + 1, pos.transform.position.z);
        obj.transform.LookAt(_rivalCastel.transform);
        WarriorStatManager.Instance.currentWarriorCount++;
        obj.GetComponent<WarriorWalk>().Walk();
        WarriorObject.Add(obj);
        WarriorBool.Add(false);
        Debug.Log("HHG");

        if (WarriorStatManager.Instance.currentWarriorCount == WarriorStatManager.Instance.warriorCount)
        {
            GameManager.Instance.inPlacement = false;
            GameManager.Instance.inMerge = true;
        }
    }

}
