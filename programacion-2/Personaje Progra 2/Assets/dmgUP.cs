using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgUP : MonoBehaviour
{
    public float value;

    private void Awake()
    {
        gameObject.GetComponent<Node>().onBuy.AddListener(onBuyHandler);
    }
    private void onBuyHandler()
    {
        DmgUp();
    }
    private void DmgUp()
    {
        SkillGraphManager.instance.player.damage += value;
    }
}
