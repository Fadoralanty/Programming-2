using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : MonoBehaviour
{
    public float value;

    private void Awake()
    {
        gameObject.GetComponent<Node>().onBuy.AddListener(onBuyHandler);
    }
    private void onBuyHandler()
    {
        MaxHpUp();
    }
    private void MaxHpUp()
    {
        SkillGraphManager.instance.player.lifeController.maxlife += value;
        SkillGraphManager.instance.player.lifeController.currentlife += value;
    }
}
