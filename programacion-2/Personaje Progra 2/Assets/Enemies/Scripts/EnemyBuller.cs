using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuller : MonoBehaviour
{
    [SerializeField] private float lifetime;//tiempo de vida del proyectil en segundos
    [SerializeField] private int damage;
    [SerializeField] private float speed;
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
            Destroy(gameObject, 0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 0f;
            LifeController player = collision.GetComponent<LifeController>();
            player.GetDamage(damage);
            animatorcontroller.SetTrigger("OnImpact");
            Destroy(gameObject, 0.2f);
        }
    }
}
