using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdUp : MonoBehaviour
{
    public float value;

    private void Awake()
    {
        gameObject.GetComponent<Node>().onBuy.AddListener(onBuyHandler);
    }
    private void onBuyHandler()
    {
        SpdUP();
    }
    private void SpdUP()
    {
        SkillGraphManager.instance.player.speed += 1;
    }
}
