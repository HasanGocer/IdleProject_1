using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoSingleton<FinishGame>
{
    public IEnumerator ControlGame()
    {
        bool infinish = false;
        while (true)
        {
            for (int i = 0; i < WarriorÝnstantiate.Instance.WarriorObject.Count; i++)
            {
                if (WarriorÝnstantiate.Instance.WarriorObject[i].activeInHierarchy)
                    infinish = true;
            }

            if (GameManager.Instance.inFinish)
            {
                infinish = true;
            }

            if (infinish == false)
            {
                if (CastleStat.Instance.health > 0)
                {
                    GameManager.Instance.inFight = false;
                    GameManager.Instance.inMerge = false;
                    GameManager.Instance.inFail = true;
                    Buttons.Instance.failGame.SetActive(true);

                }
            }
            else
            {
                GameManager.Instance.inFight = true;
                GameManager.Instance.inMerge = true;
                GameManager.Instance.inFail = false;
                Buttons.Instance.failGame.SetActive(false);
            }
            infinish = false;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
