using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private ProyectileShooter playershooter;
    [SerializeField] private TextMeshProUGUI arrowCounter;

    private void Awake()
    {
        playershooter.onAmmoChange += OnAmmoCounterChangeHandler;
    }
    public void OnAmmoCounterChangeHandler(int ammo)
    {
        UpdateCounter(ammo);
    }
    private void UpdateCounter(int num)
    {
        string updateNum = num.ToString();
        arrowCounter.text = updateNum;
    }
}
