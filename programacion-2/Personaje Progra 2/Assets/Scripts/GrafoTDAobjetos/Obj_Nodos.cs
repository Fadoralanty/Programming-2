using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Nodos 
{
    // dato de identificación del nodo
    public int id;

    // datos y métodos del objeto nodo
    public object dato1;

    public object dato2;

    public string descripcion()
    {
        return "Nodo id: " + id.ToString();
    }
}
