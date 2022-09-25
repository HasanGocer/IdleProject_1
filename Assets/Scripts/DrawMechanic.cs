using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMechanic : MonoBehaviour
{
    Touch touch;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    float vec = touch.position.x / Screen.width;
                    float vecy = touch.position.y;
                    Debug.Log(new Vector2(vec, 0));
                    break;
                case TouchPhase.Moved:

                    break;

                case TouchPhase.Ended:

                    break;
                default:
                    break;
            }
        }
    }

}
