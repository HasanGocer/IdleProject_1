using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    //nesneye deðen þeye göre bir merge mechanic çalýþtýtýr

    public int OPCount;
    public bool inChange;

    private void OnCollisionEnter(Collision collision)
    {
        //Warriorun neye deðidiðini kontrol edip ona uygun fnksiyona yönlendiriyor
        if (collision.gameObject.CompareTag("Rival"))
        {
            if (OPCount == MergeMechanic.Instance.OPLastDownCount)
            {
                inChange = true;
                MergeMechanic.Instance.LastMergeExtraction(collision.gameObject, this.gameObject);
            }
            else
            {
                inChange = true;
                MergeMechanic.Instance.MergeExtraction(collision.gameObject, this.gameObject, OPCount);
            }
        }
        else if (collision.gameObject.CompareTag("Warrior") && !inChange)
        {
            MergeObject mergeObject = collision.gameObject.GetComponent<MergeObject>();
            if (!mergeObject.inChange)
            {
                mergeObject.inChange = true;
            }
            else
            {
                inChange = true;
            }

            if (mergeObject.OPCount == OPCount && OPCount != MergeMechanic.Instance.OPLastUpCount)
            {
                inChange = true;
                MergeMechanic.Instance.MergeAdd(collision.gameObject, this.gameObject, OPCount);
            }
        }
        else if (collision.gameObject.CompareTag("Castle"))
        {
            ObjectPool.Instance.AddObject(OPCount, this.gameObject);
            CastelStat.Instance.health -= GetComponent<WarriorStat>().healthCount;
            CastleHealthBar.Instance.CastleHealthUpdate();
        }
        else if (collision.gameObject.CompareTag("Multiplication"))
        {

        }
    }
}
