using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAndFollow : MonoSingleton<DrawAndFollow>
{
    //kameradan raycast atýp deðen yerin bizim adam koup koymamýza uygun olup olmadýðýna karar veriyor ve adamlarýn objecting pooldan çekilip yürümesine kadar uzanan bir aðý tetikliyor
    
    [SerializeField] private float waypointCooldawn;
    public List<Transform> wayPoints;
    public int wayIndex;
    bool draw;
    public bool inMerge;
    public int maxRange;

    Touch touch;

    void Start()
    {
        wayIndex = 1;
        draw = true;
    }

    private void Update()
    {
        DrawTime();
    }

    public void DrawTime()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    if (draw && GameManager.Instance.inPlacement && !inMerge && GameManager.Instance.inFight)
                    {
                        draw = false;
                        StartCoroutine(WayPointsSelect());
                    }
                    break;

                case TouchPhase.Ended:
                    Debug.Log("HG3");
                    wayPoints.Clear();
                    wayIndex = 1;
                    inMerge = false;
                    draw = true;
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator WayPointsSelect()
    {
        Debug.Log("HG2");
        Vector3 worldFromMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, maxRange));
        Vector3 direction = worldFromMousePos - Camera.main.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, direction, out hit, maxRange)&& WarriorStatManager.Instance.currentWarriorCount <= WarriorStatManager.Instance.warriorCount)
        {
            Debug.Log("HG4");
            GameObject newWayPoint = new GameObject("WayPoint");
            newWayPoint.transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            wayPoints.Add(newWayPoint.transform);
            WarriorÝnstantiate.Instance.WarriorSpawn(newWayPoint);
            wayIndex++;
        }
        else
        {
            yield return null;
        }
        yield return new WaitForSeconds(waypointCooldawn);
        draw = true;

    }
}
