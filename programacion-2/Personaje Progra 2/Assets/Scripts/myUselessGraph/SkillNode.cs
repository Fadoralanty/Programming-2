using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour
{
    public int id;
    public float value;
    public string valueType;
    public SkillConnection connection;
    public SkillNode nextNode;
}
