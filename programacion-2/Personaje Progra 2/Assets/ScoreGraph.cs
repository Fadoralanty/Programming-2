using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreGraph : MonoBehaviour
{
    private TextMeshProUGUI score;
    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        score.text = SkillGraphManager.instance.Skillpoints.ToString();
    }
}
