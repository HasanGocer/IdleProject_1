using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    //Nesneye dokunuduðunda hareket ettirilebilir ama birletirme mekaniði çalýþmazsa eseki yerine býrakýr
    Vector3 distence;
    Vector3 pos;

    bool touchobject;

    private void OnMouseDown()
    {
        touchobject = true;
    }

    void Update()
    {
        if (Input.touchCount > 0 && touchobject)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    distence = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                    pos = transform.position;
                    GameManager.Instance.inPlacement = false;
                    GameManager.Instance.inMerge = true;
                    break;
                case TouchPhase.Moved:
                    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - distence);
                    DrawAndFollow.Instance.inMerge = true;
                    break;
                case TouchPhase.Ended:
                    GameManager.Instance.inPlacement = false;
                    GameManager.Instance.inMerge = true;
                    Debug.Log("sadasda");
                    if (!GetComponent<MergeObject>().inChange)
                    {
                        transform.position = pos;
                    }
                    touchobject = false;
                    //StartCoroutine(InMerge());

                    break;
                default:
                    break;
            }
        }
    }
    IEnumerator InMerge()
    {
        yield return new WaitForSeconds(0.2f);
        DrawAndFollow.Instance.inMerge = false;
    }
}
