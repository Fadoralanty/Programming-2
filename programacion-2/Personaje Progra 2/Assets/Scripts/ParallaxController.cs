﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    //Serialized
    [SerializeField] private Vector2 parallaxMultiplier;
        

    //Private
    private Vector3 lastCameraPos;
    private float textureUnitSizeX;

    //Public
    public Transform cameraTransform;

    private void Start()
    {
        //cameraTransform = Camera.main.transform;
        lastCameraPos = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPos;
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier.x, deltaMovement.y * parallaxMultiplier.y);
        lastCameraPos = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPosX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPosX, transform.position.y);
        }
    }
}
