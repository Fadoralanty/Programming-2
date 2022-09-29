using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 20f;//tiempo de vida del proyectil en segundos
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 10f;
    private float currentlifetime;//tiempo de vida actual
    private Animator animatorcontroller;
    private void Awake()
    {
        animatorcontroller = GetComponent<Animator>();
    }
    private void Update()
    {
        //Timer para destruir el proyectil
        currentlifetime += Time.deltaTime;//le sumo el paso de tiempo transcurrido al actual
        gameObject.transform.position += transform.right * speed * Time.deltaTime;
        if (currentlifetime >= lifetime)//si supera el tiempo de vida lo destruyo 
        {
            Destroy(gameObject,0.2f); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            speed = 0f;
            LifeController enemy = collision.GetComponent<LifeController>();
            enemy.GetDamage(damage);
            animatorcontroller.SetTrigger("OnImpact");
            Destroy(gameObject,0.2f);
        }
        if (collision.CompareTag("Envirorment"))
        {
            speed = 0f;
            animatorcontroller.SetTrigger("OnImpact");
            Destroy(gameObject, 0.2f);
        }
    }
}