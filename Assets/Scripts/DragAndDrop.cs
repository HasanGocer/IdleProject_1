using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //KULLANILMIYOR
    
    Vector3 distence;

    Vector3 pos;

    private void Update()
    {
        //began
        //moved
        //ended
    }

    private void OnMouseDown()
    {
        distence = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        pos = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - distence);
    }

    private void OnMouseExit()
    {
        if (!GetComponent<MergeObject>().inChange)
        {
            transform.position = pos;
        }
    }
}
