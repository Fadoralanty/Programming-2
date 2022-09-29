using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private Transform CurrentCheckpoint;
    public void RespawnPlayer()
    {
        playerTransform.transform.position = CurrentCheckpoint.position;
    }
    public void ChangeCheckpoint(Transform newCheckPoint)
    {
        CurrentCheckpoint = newCheckPoint;
    }
}