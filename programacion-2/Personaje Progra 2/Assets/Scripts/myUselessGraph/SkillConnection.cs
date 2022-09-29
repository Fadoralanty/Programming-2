using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConnection : MonoBehaviour
{
    public int id;
    public float cost;
    public SkillConnection nextConnection;
    public SkillNode destiny;
}