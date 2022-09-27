using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MergeMechanic : MonoSingleton<MergeMechanic>
{
    //birle�tirme ve ay�rma mekani�inin t�m fonksiyonlar�n�n tutuldu�u yerdir

    public int OPLastUpCount, OPLastDownCount;
    [SerializeField] private int _OPShotCount;
    [SerializeField] private int _objectCloneCount;
    //[SerializeField] private float _objectDistance;

    //Ate� ald���nda yok olup d�����n ��kmas�n� sa�laan fonksiyon
    public void MergeExtraction(GameObject objectShot, GameObject objectMerge, int OPMergeCount)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        ObjectPool.Instance.AddObject(OPMergeCount, objectMerge);
        for (int i = 0; i < _objectCloneCount; i++)
        {
            GameObject obj1 = ObjectPool.Instance.GetPooledObject(OPMergeCount - 1);
            obj1.transform.position = new Vector3(objectShot.transform.position.x, objectShot.transform.position.y, objectShot.transform.position.z);
            obj1.GetComponent<WarriorWalk>().Walk();
        }
    }

    //en d���k seviyede �l�m sonu yok olu�
    public void LastMergeExtraction(GameObject objectShot, GameObject objectMerge)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        ObjectPool.Instance.AddObject(OPLastDownCount, objectMerge);
    }

    //rivallerin birle�ip bir �st levela y�kselmesini sa�laan fonksiyon
    public void MergeAdd(GameObject obj1, GameObject obj2, int OPCount)
    {
        ObjectPool.Instance.AddObject(OPCount, obj1);
        ObjectPool.Instance.AddObject(OPCount, obj2);

        GameObject obj = ObjectPool.Instance.GetPooledObject(OPCount + 1);

        obj.transform.position = obj1.transform.position;
        obj.GetComponent<WarriorWalk>().Walk();
    }



}
