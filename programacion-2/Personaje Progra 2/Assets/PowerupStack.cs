using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupStack : MonoBehaviour
{
    public StackFILO powerups;
    public static PowerupStack instance;

    public void Start()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        powerups = new StackFILO();
        powerups.Initialize(3);
    }
    public void AddElement(GameObject element)
    {
        if (powerups.GetIndexCount() < 3)
        {
            GameObject prefab = Instantiate(element);
            powerups.Push(prefab);
            prefab.transform.SetParent(gameObject.transform);
        }
    }
    public void RemoveElement()
    {
        GameObject top = powerups.Pop();
        Destroy(top);
    }
}
