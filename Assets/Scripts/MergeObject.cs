using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObject : MonoBehaviour
{
    [SerializeField] private int _OPCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shot"))
        {
            if (_OPCount == MergeMechanic.Instance.OPLastCount)
            {
                MergeMechanic.Instance.LastMerge(collision.gameObject, this.gameObject);
            }
            else
            {
                MergeMechanic.Instance.Merge(collision.gameObject, this.gameObject, _OPCount);
            }
        }
    }
}
