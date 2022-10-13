using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MergeObject : MonoBehaviour
{
    //nesneye değen şeye göre bir merge mechanic çalıştıtır
    [SerializeField] private int OPWarriorCount;
    [SerializeField] private int intMulti;//ileride multinin içinden stat yapılıp çekilcek
    //[SerializeField] private TextMeshPro textMulti;


    public int OPCount;
    public bool inChange;

    private void OnCollisionEnter(Collision collision)
    {
        //Warriorun neye değidiğini kontrol edip ona uygun fnksiyona yönlendiriyor
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
                Warriorİnstantiate.Instance.WarriorObject.Add(obj);
                Warriorİnstantiate.Instance.WarriorBool.Add(false);
            }
            else
            {
                inChange = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Castle"))
        {
            ObjectPool.Instance.AddObject(OPCount, this.gameObject);
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
}
