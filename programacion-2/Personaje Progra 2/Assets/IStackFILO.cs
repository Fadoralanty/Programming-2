using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackFILO<Type>
{
    void Initialize(int value);

    void Push(Type item);

    Type Pop();

    Type Peek();

    bool IsEmpty();
}