using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowElement : MonoBehaviour
{
    public Text Score;

    public void SetDefaultText()
    {
        this.Score.text = "0";
    }

    public void SetInfo(int score)
    {
        this.Score.text = score.ToString();
    }
}
