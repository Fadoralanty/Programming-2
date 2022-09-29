using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI textNumber;
    private void Awake()
    {
        textNumber.text = value.ToString();
    }
    private void Update()
    {
        textNumber.text = value.ToString();
    }
}
