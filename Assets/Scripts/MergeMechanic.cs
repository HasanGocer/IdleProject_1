using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeMechanic : MonoSingleton<MergeMechanic>
{
    public int OPLastCount;
    [SerializeField] private int _OPShotCount;
    [SerializeField] private float objectDistance;

    public void Merge(GameObject objectShot, GameObject objectMerge, int OPMergeCount)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        GameObject obj1 = ObjectPool.Instance.GetPooledObject(OPMergeCount - 1);
        GameObject obj2 = ObjectPool.Instance.GetPooledObject(OPMergeCount - 1);

        ObjectPool.Instance.AddObject(OPMergeCount, objectMerge);

        obj1.transform.position = new Vector3(objectShot.transform.position.x + objectDistance, objectShot.transform.position.y, objectShot.transform.position.x - objectDistance);
        obj2.transform.position = new Vector3(objectShot.transform.position.x + objectDistance, objectShot.transform.position.y, objectShot.transform.position.x - objectDistance);

    }

    public void LastMerge(GameObject objectShot, GameObject objectMerge)
    {
        ObjectPool.Instance.AddObject(_OPShotCount, objectShot);
        ObjectPool.Instance.AddObject(OPLastCount, objectMerge);
    }
}
