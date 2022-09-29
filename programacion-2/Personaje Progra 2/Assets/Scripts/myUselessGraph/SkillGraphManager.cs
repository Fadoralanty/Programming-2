using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGraphManager : MonoBehaviour
{
    public Node origin;
    public int Skillpoints;
    public static SkillGraphManager instance;
    public PlayerCharacterController player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        origin.state = Node.nodeState.Buyable;
    }
    private void Update()
    {
        Skillpoints = GameController.Instance.currentScore;
    }
}
