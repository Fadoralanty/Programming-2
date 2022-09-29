using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeABB 
{
    //datos a almacenar, en este caso un entero
    public PlayerInfo info;

    //referencia los nodos izquierdo y derecho
    public ABBTDA LeftSon;
    public ABBTDA RightSon;
}