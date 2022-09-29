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
            for (int i = 0; i < Warriorİnstantiate.Instance.WarriorObject.Count; i++)
            {
                if (Warriorİnstantiate.Instance.WarriorObject[i].activeInHierarchy)
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
            infinish = false;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
