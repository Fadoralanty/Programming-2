using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Serialized
    [SerializeField] private Vector2 cameraSpeed;


    //Public
    public Transform playerTransform;

    //Private
    private Vector3 lastPlayerPos;

    private void Start()
    {
        lastPlayerPos = playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 movement = playerTransform.position - lastPlayerPos;
        transform.position += new Vector3(movement.x * cameraSpeed.x, movement.y * cameraSpeed.y);
        lastPlayerPos = playerTransform.position;
    }
}
