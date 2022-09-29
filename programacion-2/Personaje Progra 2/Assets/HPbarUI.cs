using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarUI : MonoBehaviour
{
    [SerializeField] private LifeController playerHP;
    [SerializeField] private Image lifeBar;
    private void Awake()
    {
        playerHP.onLifeChange += OnLifeChangeHandler;
        UpdateLifeBar();
    }
    private void OnLifeChangeHandler(float currentLife)
    {
        UpdateLifeBar();
    }
    private void UpdateLifeBar()
    {
        lifeBar.fillAmount = playerHP.GetLifePercentage();
    }
}
