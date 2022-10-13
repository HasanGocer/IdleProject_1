using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MergeMechanic : MonoSingleton<MergeMechanic>
{
    //birleþtirme ve ayýrma mekaniðinin tüm fonksiyonlarýnýn tutulduðu yerdir

    public int OPLastUpCount, OPLastDownCount;
    [SerializeField] private int _OPShotCount;
    [SerializeField] private int _OPWarriorRivalTouchParticalCount;
    [SerializeField] private int _OPWarriorSpawnParticalCount;
    [SerializeField] private int _OPMergeParitcalCount;
    [SerializeField] private int _objectCloneCount;
    [SerializeField] private float _ParticalOnTime;
    //[SerializeField] private float _objectDistance;

    //Ateþ aldýðýnda yok olup düþüðün çýkmasýný saðlaan fonksiyon
    public void MergeExtraction(GameObject objectShot, GameObject objectMerge, int OPMergeCount)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        ObjectPool.Instance.AddObject(OPMergeCount, objectMerge);

        GameObject partical1 = ObjectPool.Instance.GetPooledObjectAdd(_OPWarriorRivalTouchParticalCount);
        partical1.transform.position = new Vector3(objectShot.transform.position.x, objectShot.transform.position.y + 2, objectShot.transform.position.z);

        GameObject partical2 = ObjectPool.Instance.GetPooledObjectAdd(_OPWarriorRivalTouchParticalCount);
        partical1.transform.position = new Vector3(objectMerge.transform.position.x, objectMerge.transform.position.y + 2, objectMerge.transform.position.z);

        for (int i = 0; i < _objectCloneCount; i++)
        {
            GameObject obj1 = ObjectPool.Instance.GetPooledObject(OPMergeCount - 1);
            obj1.transform.position = new Vector3(objectShot.transform.position.x, objectShot.transform.position.y, objectShot.transform.position.z);
            obj1.GetComponent<WarriorWalk>().Walk();

            GameObject partical = ObjectPool.Instance.GetPooledObjectAdd(_OPWarriorSpawnParticalCount);
            partical.transform.position = obj1.transform.position;
            StartCoroutine(ParticalFalse(partical));
        }
    }

    //en düþük seviyede ölüm sonu yok oluþ
    public void LastMergeExtraction(GameObject objectShot, GameObject objectMerge)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        ObjectPool.Instance.AddObject(OPLastDownCount, objectMerge);

        GameObject partical1 = ObjectPool.Instance.GetPooledObjectAdd(_OPWarriorRivalTouchParticalCount);
        partical1.transform.position = new Vector3(objectShot.transform.position.x, objectShot.transform.position.y + 2, objectShot.transform.position.z);

        GameObject partical2 = ObjectPool.Instance.GetPooledObjectAdd(_OPWarriorRivalTouchParticalCount);
        partical1.transform.position = new Vector3(objectMerge.transform.position.x, objectMerge.transform.position.y + 2, objectMerge.transform.position.z);
    }

    //rivallerin birleþip bir üst levela yükselmesini saðlaan fonksiyon
    public GameObject MergeAdd(GameObject obj1, GameObject obj2, int OPCount)
    {
        ObjectPool.Instance.AddObject(OPCount, obj1);
        ObjectPool.Instance.AddObject(OPCount, obj2);

        GameObject partical1 = ObjectPool.Instance.GetPooledObjectAdd(_OPMergeParitcalCount);
        partical1.transform.position = obj1.transform.position;

        GameObject partical2 = ObjectPool.Instance.GetPooledObjectAdd(_OPMergeParitcalCount);
        partical2.transform.position = obj2.transform.position;

        GameObject obj = ObjectPool.Instance.GetPooledObject(OPCount + 1);

        obj.transform.position = obj1.transform.position;
        obj.GetComponent<WarriorWalk>().Walk();

        return obj;
    }

    void LastParticleObjectOnCastle()
    {
        
    }
    IEnumerator ParticalFalse(GameObject partical)
    {
        yield return new WaitForSeconds(_ParticalOnTime);
        partical.SetActive(false);
    }

}
