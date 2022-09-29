using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public List<Connection> connections = new List<Connection>();
    public enum nodeState { Locked, Buyable, Bought };
    public nodeState state;
    private Button button;
    public int mycost;
    public UnityEvent onBuy;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(buy);
    }
    private void Update()
    {
        if(state == nodeState.Buyable)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    public void buy()
    {
        if (GameController.Instance.currentScore < mycost) { return; }
        onBuy.Invoke();
        state = nodeState.Bought;
        GameController.Instance.currentScore -= mycost;
        foreach(Connection connection in connections)
        {
            if (connection.node.state == nodeState.Locked)
            {
                connection.node.state = nodeState.Buyable;
            }
            if (connection.node.mycost > connection.cost)
            {
                connection.node.mycost = connection.cost;
            }
        }
    }
}

