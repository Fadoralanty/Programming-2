using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ABBTDA 
{
    PlayerInfo Root();

    ABBTDA LeftSon();

    ABBTDA RightSon();

    bool TreeEmpty();

    void InitiateTree();

    void AddElement(PlayerInfo x);

    void RemoveElement(PlayerInfo x);
}