using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MergeObject : MonoBehaviour
{
    //nesneye de�en �eye g�re bir merge mechanic �al��t�t�r
    [SerializeField] private int OPWarriorCount;
    [SerializeField] private int _OPTouchCastlePartical = 8;
    [SerializeField] private int intMulti;//ileride multinin i�inden stat yap�l�p �ekilcek
    public bool inDrag;
    //[SerializeField] private TextMeshPro textMulti;


    public int OPCount;
    public bool inChange;

    private void OnCollisionEnter(Collision collision)
    {
        //Warriorun neye de�idi�ini kontrol edip ona uygun fnksiyona y�nlendiriyor
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
                GameObject obj = MergeMechanic.Instance.MergeAdd(collision.gameObject, this.gameObject, OPCount);
                Warrior�nstantiate.Instance.WarriorObject.Add(obj);
                Warrior�nstantiate.Instance.WarriorBool.Add(false);
            }
            else
            {
                inChange = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Castle") && !inDrag)
        {
            ObjectPool.Instance.AddObject(OPCount, this.gameObject);
            StartCoroutine(CastleTouch(other.gameObject));
            CastleStat.Instance.health -= GetComponent<WarriorStat>().healthCount;
            CastleHealthBar.Instance.CastleHealthUpdate();
            GameManager.Instance.money += GameManager.Instance.addedMoney;
            GameManager.Instance.SetMoney();
            Buttons.Instance.moneyText.text = GameManager.Instance.money.ToString();

        }
        else if (other.CompareTag("Multiplication"))
        {
            //textMulti.text = intMulti.ToString();
            for (int i = 0; i < intMulti - 1; i++)
            {
                GameObject obj = ObjectPool.Instance.GetPooledObject(OPWarriorCount);
                obj.transform.position = this.transform.position;
                obj.transform.LookAt(WarriorStatManager.Instance.CastlePos.transform.position);
            }
        }
    }

    IEnumerator CastleTouch(GameObject other)
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPTouchCastlePartical);
        obj.transform.position = other.transform.position;
        yield return new WaitForSeconds(3f);
        ObjectPool.Instance.AddObject(_OPTouchCastlePartical, obj);
    }
}
