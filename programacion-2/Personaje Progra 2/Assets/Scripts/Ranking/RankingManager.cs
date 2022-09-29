using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    ABB abb = new ABB();
    public List<GameObject> rowElement;

    private void Start()
    {
        abb.InitiateTree();
    }

    public void AddPlayerOnRanking()
    {
        abb.AddElement(new PlayerInfo());
        UpdateScreen();
    }

    public void RemovePlayerFromRanking()
    {
        abb.RemoveElement(!abb.LeftSon().TreeEmpty() ? abb.Lower(abb.LeftSon()) : abb.Higher(abb.RightSon()));
        UpdateScreen();
    }

    private void UpdateScreen()
    {
        for (int i = 0; i < 1; i++)
        {
            rowElement[i].GetComponent<RowElement>().SetDefaultText();
        }

        if (!abb.TreeEmpty())
        {
            var higherScore = abb.Higher(abb);
            if (higherScore != null)
            {
                rowElement[0].GetComponent<RowElement>().SetInfo(higherScore.Score);
            }

            var lowerscore = abb.Lower(abb);
            if (lowerscore != null)
            {
                rowElement[1].GetComponent<RowElement>().SetInfo(lowerscore.Score);
            }
        }
    }
}