using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float autoDestroyTimer;
    [SerializeField] private float speed = 0f;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        autoDestroyTimer += Time.time;
    }

    void Update()
    { 
       transform.Translate(-speed * Time.deltaTime, 0, 0);
            
        if (Time.time > autoDestroyTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifeController life = collision.GetComponent<LifeController>(); 
        if (life != null) 
        {
            life.GetDamage(damage);
            Destroy(gameObject);
        }
    }
    
}
