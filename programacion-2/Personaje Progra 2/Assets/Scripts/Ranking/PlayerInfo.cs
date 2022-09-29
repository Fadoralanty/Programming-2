using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int Score { get; set; }

    public PlayerInfo()
    {
        this.Score = GameController.Instance.GetFinalScore();
    }
}
